using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using FluentResults;
using SSS.Application.Common.Errors;
using SSS.Application.Services.Authentication.Common;

namespace SSS.Application.Services.Authentication.Queries;

public interface IAuthenticationQueryService
{
    public ErrorOr<AuthenticationResult> Login(string email, string password);
}
