using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SSS.Application.Services.Authentication.Commands;
using SSS.Application.Services.Authentication.Common;
using SSS.Application.Services.Authentication.Queries;
using SSS.Contracts.Authentication;
using SSS.Domain.Common.Errors;

namespace SSS.Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController(
        IAuthenticationCommandService authenticationCommandService,
        IAuthenticationQueryService authenticationQueryService) : ApiController
    {
        private readonly IAuthenticationCommandService _authenticationCommandService = authenticationCommandService;
        private readonly IAuthenticationQueryService _authenticationQueryService = authenticationQueryService;

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest registerRequest)
        {
            ErrorOr<AuthenticationResult> authResult = _authenticationCommandService.Register(
                registerRequest.Username,
                registerRequest.Email,
                registerRequest.Password,
                registerRequest.FirstName,
                registerRequest.LastName);

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors)
            );
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            var authResult = _authenticationQueryService.Login(
                loginRequest.Email,
                loginRequest.Password);

            if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
            }

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors)
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
    }
}