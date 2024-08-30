using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSS.Application.Services.Authentication;

public record AuthenticationResult(
    string Message,
    User User,
    string Token
);

public record User(
    Guid Id,
    string Email,
    string CreatedAt
);