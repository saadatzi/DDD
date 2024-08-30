using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SSS.Application.Common.Interfaces.Authentication;
using SSS.Application.Common.Interfaces.Persistence;
using SSS.Application.Common.Interfaces.Services;
using SSS.Infrastructure.Authentication;
using SSS.Infrastructure.Persistence;
using SSS.Infrastructure.Services;

namespace SSS.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<JwtSetting>(configuration.GetSection(JwtSetting.SectionName));
        
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
    
}
