using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using FluentResults;
using SSS.Application.Common.Errors;
using SSS.Application.Services.Authentication.Common;

namespace SSS.Application.Services.Authentication.Commands;

public interface IAuthenticationCommandService
{
    public ErrorOr<AuthenticationResult> Register(
        string username,
        string email,
        string password,
        string firstname,
        string lastname);
}
