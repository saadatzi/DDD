using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SSS.Application.Common.Interfaces.Authentication;
using SSS.Application.Common.Interfaces.Services;
using SSS.Infrastructure.Authentication;
using SSS.Infrastructure.Services;

namespace SSS.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<JwtSetting>(configuration.GetSection(JwtSetting.SectionName));
        
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        return services;
    }
    
}
