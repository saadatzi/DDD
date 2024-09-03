using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Identity.Data;
using SSS.Application.Authentication.Commands.Register;
using SSS.Application.Authentication.Common;
using SSS.Application.Authentication.Queries.Login;

namespace SSS.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>(); // although it is redundant it is more neat to know where to refer if it is required.
        
        config.NewConfig<LoginRequest, LoginQuery>(); // although it is redundant it is more neat to know where to refer if it is required.

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            // .Map(dest => dest.Token, src => src.Token) // is not required since same name is mapped automatically
            .Map(dest => dest, src => src.User);
    }
}
