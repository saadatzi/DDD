using Microsoft.AspNetCore.Mvc.Infrastructure;
using SSS.Api.Common.Errors;
using SSS.Api.Common.Mapping;

namespace SSS.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {

        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, SSSProblemDetailsFactory>();
        services.AddMappings();
        return services;
    }
}
