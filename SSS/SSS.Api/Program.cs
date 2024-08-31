using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SSS.Api.Errors;
using SSS.Application;
using SSS.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    // app.UseExceptionHandler("/error");
    // Minimal api approach 
    app.Map("/error", (HttpContext httpcontext) =>
    {
        Exception? exception = httpcontext.Features.Get<IExceptionHandlerFeature>()?.Error;

        return Results.Problem(title: exception?.Message); // similar to problem in the error controller
    });
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}