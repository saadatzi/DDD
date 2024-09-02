using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;
using OneOf;
using SSS.Application.Common.Errors;

namespace SSS.Application.Services.Authentication;

public interface IAuthenticationService
{
    public AuthenticationResult Login(string email, string password);
    public Result<AuthenticationResult> Register(
        string username,
        string email,
        string password,
        string firstname,
        string lastname);
}
