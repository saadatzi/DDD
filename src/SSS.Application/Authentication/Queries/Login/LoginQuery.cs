using ErrorOr;
using MediatR;
using SSS.Application.Authentication.Common;

namespace SSS.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;