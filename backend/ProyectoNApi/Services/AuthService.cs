using System.Security.Claims;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        /// 
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
    }
}