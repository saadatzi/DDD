using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using SSS.Application.Common.Interfaces.Authentication;
using SSS.Application.Common.Interfaces.Services;
using SSS.Domain.Entities;

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
        _dateTimeProvider = dateTimeProvider;
    }

    AuthenticationResult IAuthenticationService.Register(
        string username,
        string email,
        string password,
        string firstname,
        string lastname)
    {
        // 2. Create user (generate unique Id) & Persist to DB
        var user = new User
        {
            Username = username,
            Email = email,
            PasswordHash = password,
            FirstName = firstname,
            LastName = lastname

        };
        return new AuthenticationResult(
            "login successfuly",
            user,
            token);
    }
    AuthenticationResult IAuthenticationService.Login(string email, string password)
    {
        Guid userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, email);

        return new AuthenticationResult(
            "login successfuly",
            user,
            token);
    }

}
