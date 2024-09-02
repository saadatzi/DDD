using Microsoft.AspNetCore.Mvc;
using OneOf;
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
            OneOf.OneOf<AuthenticationResult, IError> registerResult = _authenticationService.Register(
                registerRequest.Username,
                registerRequest.Email,
                registerRequest.Password,
                registerRequest.FirstName,
                registerRequest.LastName);

            return registerResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                error => Problem(statusCode: (int)error.StatusCode, title: error.ErrorMessage)
            );
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