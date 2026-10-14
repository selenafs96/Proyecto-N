using Microsoft.AspNetCore.Mvc;

using ProyectoNApi.Services;
using ProyectoNApi.Models.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace ProyectoNApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
            {
                _authService = authService;
            }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            AuthResult authResult = await _authService.RegisterAsync(registerDto);
            if (!authResult.Success)
            {
                return BadRequest(authResult.Errors);
            }

            return StatusCode(StatusCodes.Status201Created, new { message = "Usuario registrado correctamente" });
        }

        /// <summary>
        /// Local login
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns>Status code</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var result = await _authService.LoginAsync(loginDto);

            if (!result.Success)
            {
                return Unauthorized(new { message = "Credenciales incorrectas" });
            }

            return Ok(new { message = "Inicio de sesión exitoso" });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return Ok(new { message = "Sesión cerrada correctamente" });
        }

        // /// <summary>
        // /// Checks if the authentication cookie is still valid and returns the current user profile.
        // /// ControlerBase has a User property that returns a ClaimPrincipal
        // </summary>
        // /// <returns></returns>
        [Authorize] // User must be authenticated, returns 401 if not
        [HttpGet("me")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userDto = await _authService.GetCurrentUserAsync(User);
            if (userDto == null )
                {
                    return Unauthorized(new { message = "Usuario no autenticado."});
                }
            return Ok(userDto);
        }

        /// <summary>
        /// Configures the request for Google and redirects to accounts.google.com
        /// </summary>
        /// <returns></returns>
        [HttpGet("signin-google")]
        public IActionResult SignInGoogle()
        {
            var redirectUrl = "/api/auth/google-response";
            // Configure using ASP.NET Core Identity the request for Google
            var properties = _authService.ConfigureGoogleProperties(redirectUrl);

            // 3. Challenge() authomatically redirects the user to accounts.google.com
            return Challenge(properties, "Google");
        }

        /// <summary>
        /// Checks if the authentication has been successful and returns an error or redirects to the corresponding page
        /// </summary>
        /// <returns></returns>
        [HttpGet("google-response")]
        public async Task<IActionResult> GoogleResponse()
        {
            var (Succeeded, RedirectUrl, ErrorMessage) = await _authService.GoogleResponse();

            if (!Succeeded)
            {
                return BadRequest(new { message = ErrorMessage });
            }

            // Redirects to the dashboard or the conmplete-profile page
            return Redirect(RedirectUrl);
        }
    }
}
