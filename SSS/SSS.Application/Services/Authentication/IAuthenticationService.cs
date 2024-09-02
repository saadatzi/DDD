using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using FluentResults;
using SSS.Application.Common.Errors;

namespace SSS.Application.Services.Authentication;

public interface IAuthenticationService
{
    public ErrorOr<AuthenticationResult> Login(string email, string password);
    public ErrorOr<AuthenticationResult> Register(
        string username,
        string email,
        string password,
        string firstname,
        string lastname);
}
