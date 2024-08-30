using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using SSS.Application.Common.Interfaces.Authentication;
using SSS.Application.Common.Interfaces.Services;

namespace SSS.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IDateTimeProvider _dateTimeProvider;

    public AuthenticationService(
        IJwtTokenGenerator jwtTokenGenerator,
        IDateTimeProvider dateTimeProvider)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    AuthenticationResult IAuthenticationService.Login(string email, string password)
    {
        return new AuthenticationResult(
            "login successfuly",
            new User(Guid.NewGuid(), email, DateTime.UtcNow.ToString()),
            "Token");
    }

    AuthenticationResult IAuthenticationService.Register(string username, string email, string password)
    {
        // Check if user already exists
        // Create user (generate unique Id)
        // Create JWT Token
        Guid userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, email);
        return new AuthenticationResult(
            "login successfuly",
            new User(
                userId,
                email,
            token);
    }
    AuthenticationResult IAuthenticationService.Login(string email, string password)
    {
        Guid userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, email);

        return new AuthenticationResult(
            "login successfuly",
            new User(
                Guid.NewGuid(),
                email,
            new User(Guid.NewGuid(), email, DateTime.UtcNow.ToString()),
            "Token");
            token);
    }

}
