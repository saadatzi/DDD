using Microsoft.AspNetCore.Mvc;
using SSS.Api.Filters;
using SSS.Application.Services.Authentication;
using SSS.Contracts.Authentication;


[ApiController]
[Route("auth")]
[ErrorHandlingFilter]
public class AuthenticationController : ControllerBase {
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest registerRequest) {
        var authResult = _authenticationService.Register(
            registerRequest.Username,
            registerRequest.Email,
            registerRequest.Password,
            registerRequest.FirstName,
            registerRequest.LastName);

        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.Email,
            authResult.Token
        );

        return Ok(authResult);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest loginRequest) {
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