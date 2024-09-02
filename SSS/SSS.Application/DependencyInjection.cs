using Microsoft.Extensions.DependencyInjection;
using SSS.Application.Services.Authentication.Commands;
using SSS.Application.Services.Authentication.Queries;

namespace SSS.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
        services.AddScoped<IAuthenticationQueryService, AuthenticationQueryhService>();

        return services;
    }
}
