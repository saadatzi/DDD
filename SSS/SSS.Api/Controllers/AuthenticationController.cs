using FluentResults;
using Microsoft.AspNetCore.Mvc;
using SSS.Application.Common.Errors;
using SSS.Application.Services.Authentication;
using SSS.Contracts.Authentication;

namespace SSS.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController(IAuthenticationService authenticationService) : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest registerRequest)
        {
            Result<AuthenticationResult> registerResult = _authenticationService.Register(
                registerRequest.Username,
                registerRequest.Email,
                registerRequest.Password,
                registerRequest.FirstName,
                registerRequest.LastName);

            if (registerResult.IsSuccess)
            {
                return Ok(MapAuthResult(registerResult.Value));
            }

            var error = registerResult.Errors[0];

            if (error is DuplicateEmailError)
            {
                return Problem(statusCode: StatusCodes.Status409Conflict, title: $"User with this email already exists: {registerRequest.Email}");
            }

            return Problem();
            
        }

        private static AuthenticationResponse MapAuthResult(AuthenticationResult registerResult)
        {
            return new AuthenticationResponse(
                            registerResult.User.Id,
                            registerResult.User.Email,
                            registerResult.Token
                        );
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            var authResult = _authenticationService.Login(
                loginRequest.Email,
                loginRequest.Password);

            var response = new AuthenticationResponse(
                authResult.User.Id,
                authResult.User.Email,
                authResult.Token
            );

            return Ok(response);
        }
    }
}