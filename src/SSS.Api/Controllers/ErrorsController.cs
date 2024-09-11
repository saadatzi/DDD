using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

using SSS.Application.Common.Errors;

namespace SSS.Api.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var (statusCode, errorMessage) = exception switch
        {
            IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
            _ => (StatusCodes.Status500InternalServerError, exception?.Message),
        };

        return Problem(statusCode: statusCode, title: errorMessage);
    }
}