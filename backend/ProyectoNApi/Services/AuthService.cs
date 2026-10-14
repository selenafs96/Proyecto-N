using System.Security.Claims;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using ProyectoNApi.Entities;
using ProyectoNApi.Models.Dtos;

namespace ProyectoNApi.Services
{
    public interface IAuthService
    {
        Task<AuthResult> RegisterAsync(RegisterDto registerDto);
        Task<AuthResult> LoginAsync(LoginDto loginDto);
        Task LogoutAsync();
        Task<UserDto?> GetCurrentUserAsync(ClaimsPrincipal identity);
        AuthenticationProperties ConfigureGoogleProperties (string redirectUrl);
        Task<(bool Succeeded, string RedirectUrl, string ErrorMessage)> GoogleResponse();

    }

    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IValidator<User> _userValidator;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, IValidator<User> userValidator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userValidator = userValidator;
        }

        public async Task<AuthResult> RegisterAsync(RegisterDto registerDto)
        {
             // Creates user entity using RegisterDto data
            var user = new User
            {
                UserName = registerDto.Email,
                Email = registerDto.Email,
                Name = registerDto.Name,
                PhoneNumber = registerDto.PhoneNumber,
                LastName = registerDto.LastName,
                Dni = registerDto.Dni,
                PhotoUrl = !string.IsNullOrEmpty(registerDto.PhotoUrl) ? registerDto.PhotoUrl : null
            };

            // Execute UserValidator
            var validationResult = await _userValidator.ValidateAsync(user);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
                return new AuthResult
                {
                    Success = false,
                    Errors = errors,
                    User = null
                };
            }

            // If it's valid, Identity creates the user and hashes the password.
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => new { PropertyName = e.Code, ErrorMessage = e.Description });
                return new AuthResult
                {
                    Success = false,
                    Errors = errors,
                    User = null
                };
            }

            // Authomatically  generates the httpOnly cookie and logs in
            await _signInManager.SignInAsync(user, isPersistent: true);
            return new AuthResult
                {
                    Success = true,
                    Errors = null,
                    User = user
                };
        }

        public async Task<AuthResult> LoginAsync(LoginDto loginDto)
        {
            // TODO change lockoutOnFailure value to improve security ?
            var result = await _signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password, isPersistent: true, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                return new AuthResult
                {
                    Success = false,
                    Errors =
                    [
                        new
                        {
                            PropertyName = "Credentials",
                            ErrorMessage = "Incorrect credentials."
                        }
                    ],
                    User = null
                };
            }

            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            return new AuthResult
            {
                Success = true,
                Errors = null,
                User = user
            };
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        /// <summary>
        /// Returns the current user information
        /// </summary>
        /// <param name="identity">ClaimsPrincipal is the result of unpackaging an httpOnly cookie</param>
        /// <returns></returns>
        public async Task<UserDto?> GetCurrentUserAsync(ClaimsPrincipal identity)
        {
             var user = await _userManager.GetUserAsync(identity);
            
            if (user is null)
            {
                return null;
            }

            return new UserDto
            {
                Dni = user.Dni,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email!,
                PhoneNumber = user.PhoneNumber!,
                PhotoUrl = (!string.IsNullOrEmpty(user.PhotoUrl)) ? user.PhotoUrl : null 
            };
        }

         /// <summary>
        /// Configures the request for Google and redirects to accounts.google.com
        /// </summary>
        /// <returns>AuthenticacionProperties</returns>
        public AuthenticationProperties ConfigureGoogleProperties(string redirectUrl)
        {
            return _signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
        }

        /// <summary>
        /// Processes the Google sign-in response, creates an account if needed, and signs in the user.
        /// Users without a DNI are redirected to complete their profile; other users are sent to the dashboard.
        /// </summary>
        /// <returns>
        /// A tuple indicating whether the operation succeeded, the URL to redirect to, and any error message.
        /// </returns>
        public async Task<(bool Succeeded, string RedirectUrl, string ErrorMessage)> GoogleResponse()
        {
            // Checks the Google Temp data from the HTTP request
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null) return (false, string.Empty, "Error con Google.");

            // Checks if the user already exists
            var email = info.Principal.FindFirstValue(ClaimTypes.Email)!;
            var user = await _userManager.FindByEmailAsync(email);

            bool isNewUser = false;

            if (user == null)
            {
                // Creates the basic user using google information
                user = new User { UserName = email, Email = email, EmailConfirmed = true };
                await _userManager.CreateAsync(user);
                await _userManager.AddLoginAsync(user, info);
                isNewUser = true;
            }

            // Sign In (creating HttpOnly cookie)
            await _signInManager.SignInAsync(user, isPersistent: false);

            // Checks if the user has DNI or it's a new user
            if (isNewUser || string.IsNullOrEmpty(user.Dni))
            {
                // Redirect to the complete-profile Next.js page to complete his data
                return (true, "http://localhost:3000/complete-profile", string.Empty);
            }

            // Redirects to dashboard
            return (true, "http://localhost:3000/dashboard", string.Empty);
        }
    }
}