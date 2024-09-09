using SSS.Domain.Entities;

namespace SSS.Application.Authentication.Common;
public record AuthenticationResult(
    string Message,
    User User,
    string Token);