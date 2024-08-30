using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSS.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    AuthenticationResult IAuthenticationService.Login(string email, string password)
    {
        return new AuthenticationResult(
            "login successfuly",
            new User(Guid.NewGuid(), email, DateTime.UtcNow.ToString()),
            "Token");
    }

    AuthenticationResult IAuthenticationService.Register(string username, string email, string password)
    {
        return new AuthenticationResult(
            "login successfuly",
            new User(Guid.NewGuid(), email, DateTime.UtcNow.ToString()),
            "Token");
    }
}
