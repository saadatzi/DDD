using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SSS.Api.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        context.Result = new ObjectResult(new { error = $"An error accurred while processing your request."}){
            StatusCode = 500
        };

        context.ExceptionHandled = true;
    }
}
