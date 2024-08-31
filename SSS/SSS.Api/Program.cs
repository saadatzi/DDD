using SSS.Api.Filters;
using SSS.Application;
using SSS.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers(option => option.Filters.Add<ErrorHandlingFilterAttribute>());
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}