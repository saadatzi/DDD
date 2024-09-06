using System.Reflection;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SSS.Application.Authentication.Commands.Register;
using SSS.Application.Authentication.Common;
using SSS.Application.Common.Behaviors;
namespace SSS.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);

        services.AddScoped(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));
        
        // services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidator>(); // This way we need to wire(DI) each validator
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); // so we install aspnetcore package of FluentValidator
            
        return services;
    }
}
