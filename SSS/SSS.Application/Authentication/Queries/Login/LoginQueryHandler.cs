using ErrorOr;
using MediatR;
using SSS.Application.Authentication.Common;
using SSS.Application.Common.Interfaces.Authentication;
using SSS.Application.Common.Interfaces.Persistence;
using SSS.Domain.Common.Errors;
using SSS.Domain.Entities;

namespace SSS.Application.Authentication.Queries.Login;

public class LoginQueryHandler :
    IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        if (_userRepository.GetUserByEmail(query.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (user.PasswordHash != query.Password)
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