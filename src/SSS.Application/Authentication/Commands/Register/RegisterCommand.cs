using ErrorOr;
using MediatR;
using SSS.Application.Authentication.Common;

namespace SSS.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string Username,
    string Email,
    string Password,
    string FirstName,
    string LastName)
    : IRequest<ErrorOr<AuthenticationResult>>;