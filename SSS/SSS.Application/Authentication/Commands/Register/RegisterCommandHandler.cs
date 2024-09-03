using ErrorOr;
using MediatR;
using SSS.Application.Authentication.Common;
using SSS.Application.Common.Interfaces.Authentication;
using SSS.Application.Common.Interfaces.Persistence;
using SSS.Domain.Common.Errors;
using SSS.Domain.Entities;

namespace SSS.Application.Authentication.Commands.Register;

public class RegisterCommandHandler :
    IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // 1. Check if user already exists
        if (_userRepository.GetUserByEmail(command.Email) != null)
        {
            return Errors.User.DuplicateEmail;
        }
        // 2. Create user (generate unique Id) & Persist to DB
        User user = new()
        {
            Username = command.Username,
            Email = command.Email,
            PasswordHash = command.Password,
            FirstName = command.FirstName,
            LastName = command.LastName

        };
        _userRepository.AddUser(user);
        // 3. Create JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            "login successfuly",
            user,
            token);
    }
}
