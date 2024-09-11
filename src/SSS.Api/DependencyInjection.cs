using Microsoft.AspNetCore.Mvc.Infrastructure;

using SSS.Api.Common.Errors;
using SSS.Api.Common.Mapping;

namespace SSS.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowNamedFloatingPointLiterals;
            });
        services.AddSingleton<ProblemDetailsFactory, SSSProblemDetailsFactory>();
        services.AddMappings();
        return services;
    }
}