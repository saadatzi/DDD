using ErrorOr;

using FluentValidation;

using MediatR;

namespace SSS.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_validator is null)
        {
            return await next();
        }

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid)
        {
            return await next();
        }

        var errors = validationResult.Errors
            .ConvertAll(validationFailure => ErrorOr.Error.Validation(
                validationFailure.PropertyName,
                validationFailure.ErrorMessage));

        // (dynamic) it will check in the runtime if there is a way to turn errors list into error objects
        // Otherwise we can use the reflection approach can be found in the erroror readme
        // Since that we know when we arrive at this point we have list of errors that can be convert to erroror object
        return (dynamic)errors;
    }
}