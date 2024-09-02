using System.Security.Authentication;
using OneOf;
using SSS.Application.Common.Errors;
using SSS.Application.Common.Interfaces.Authentication;
using SSS.Application.Common.Interfaces.Persistence;
using SSS.Application.Common.Interfaces.Services;
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

    public OneOf<AuthenticationResult, IError> Register(
        string username,
        string email,
        string password,
        string firstname,
        string lastname)
    {
        // 1. Check if user already exists
        if(_userRepository.GetUserByEmail(email) != null)
        {
            return new DuplicateEmailError();
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
    public AuthenticationResult Login(string email, string password)
    {
        var user = _userRepository.GetUserByEmail(email) ?? throw new DuplicateEmailException($"The User doesn't exists with this email: {email}");
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
