using FluentValidation;
using MediatR;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        // Perform validation
        var context = new ValidationContext<TRequest>(request);
        var validationResults = _validators.Select(v => v.Validate(context)).ToList();

        if (validationResults.Any(r => !r.IsValid))
        {
            var errors = validationResults.SelectMany(r => r.Errors).Select(e => e.ErrorMessage).ToList();
            var errorMessage = string.Join(", ", errors);

            var failureResponse = typeof(TResponse).GetMethod("Failure")?.Invoke(null, new object[] { errorMessage });
            return (TResponse)failureResponse!;
        }

        var response = await next();

        return response;
    }
}
