using Microsoft.Extensions.DependencyInjection;
using SSS.Application.Services.Authentication;

namespace SSS.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}
