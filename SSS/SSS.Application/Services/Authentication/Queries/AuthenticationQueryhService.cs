using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Security.Authentication;
using ErrorOr;
using FluentResults;
using SSS.Application.Common.Errors;
using SSS.Application.Common.Interfaces.Authentication;
using SSS.Application.Common.Interfaces.Persistence;
using SSS.Application.Common.Interfaces.Services;
using SSS.Application.Services.Authentication.Commands;
using SSS.Application.Services.Authentication.Common;
using SSS.Domain.Common.Errors;
using SSS.Domain.Entities;

namespace SSS.Application.Services.Authentication.Queries;

public class AuthenticationQueryhService(
    IJwtTokenGenerator jwtTokenGenerator,
    IDateTimeProvider dateTimeProvider,
    IUserRepository userRepository) : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
    private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;
    private readonly IUserRepository _userRepository = userRepository;
    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not User user)
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
