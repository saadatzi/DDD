using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SSS.Domain.Entities;

namespace SSS.Application.Services.Authentication.Common;

public record AuthenticationResult(
    string Message,
    User User,
    string Token
);