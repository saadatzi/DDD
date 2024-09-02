using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Security.Authentication;
using ErrorOr;
using FluentResults;
using SSS.Application.Common.Errors;
using SSS.Application.Common.Interfaces.Authentication;
using SSS.Application.Common.Interfaces.Persistence;
using SSS.Application.Common.Interfaces.Services;
using SSS.Domain.Common.Errors;
using SSS.Domain.Entities;

namespace SSS.Application.Services.Authentication;

public class AuthenticationService(
    IJwtTokenGenerator jwtTokenGenerator,
    IDateTimeProvider dateTimeProvider,
    IUserRepository userRepository) : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
    private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;
    private readonly IUserRepository _userRepository = userRepository;

    public ErrorOr<AuthenticationResult> Register(
        string username,
        string email,
        string password,
        string firstname,
        string lastname)
    {
        // 1. Check if user already exists
        if(_userRepository.GetUserByEmail(email) != null)
        {
            return Errors.User.DuplicateEmail;
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
    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        if(_userRepository.GetUserByEmail(email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        } 

        if (user.PasswordHash != password)
        {
            return new[] { Errors.Authentication.InvalidCredentials };
            
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            "login successfuly",
            user,
            token);
    }

}
