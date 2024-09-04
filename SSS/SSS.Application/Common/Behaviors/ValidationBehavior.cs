using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;
using SSS.Application.Authentication.Commands.Register;
using SSS.Application.Authentication.Common;

namespace SSS.Application.Common.Behaviors;

public class ValidationRegisterCommandBehavior : 
    IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    public async Task<ErrorOr<AuthenticationResult>> Handle(
        RegisterCommand request,
        RequestHandlerDelegate<ErrorOr<AuthenticationResult>> next,
        CancellationToken cancellationToken)
    {
        // before the handler
        var result = await next();
        // after the handler

        return result;
    }
}
