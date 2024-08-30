using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Authentication;
using System.Threading.Tasks;
using SSS.Application.Common.Interfaces.Authentication;
using SSS.Application.Common.Interfaces.Persistence;
using SSS.Application.Common.Interfaces.Services;
using SSS.Domain.Entities;

namespace SSS.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(
        IJwtTokenGenerator jwtTokenGenerator,
        IDateTimeProvider dateTimeProvider,
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _dateTimeProvider = dateTimeProvider;
        _userRepository = userRepository;
    }

    AuthenticationResult IAuthenticationService.Register(
        string username,
        string email,
        string password,
        string firstname,
        string lastname)
    {
        // 1. Check if user already exists
        if(_userRepository.GetUserByEmail(email) != null)
        {
            throw new InvalidOperationException($"The User already exists with this email: {email}");
        }
        // 2. Create user (generate unique Id) & Persist to DB
        var user = new User
        {
            Username = username,
            Email = email,
            PasswordHash = password,
            FirstName = firstname,
            LastName = lastname

        };
        _userRepository.AddUser(user);
        // 3. Create JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            "login successfuly",
            user,
            token);
    }
    AuthenticationResult IAuthenticationService.Login(string email, string password)
    {
        var user = _userRepository.GetUserByEmail(email) ?? throw new InvalidOperationException($"The User doesn't exists with this email: {email}");
        if (user.PasswordHash != password)
        {
            throw new AuthenticationException("Invalid password.");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            "login successfuly",
            user,
            token);
    }

}
