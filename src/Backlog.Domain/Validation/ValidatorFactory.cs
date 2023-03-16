using FluentValidation;
using System;


namespace Backlog.Domain.Validation;

public class ValidatorFactory : IValidatorFactory
{
    private readonly IServiceProvider _serviceProvider;

    public ValidatorFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IValidator<T> GetValidator<T>()
    {
        return _serviceProvider.GetService(typeof(T)) as IValidator<T>;
    }

    public IValidator GetValidator(Type type)
    {
        return _serviceProvider.GetService(type) as IValidator;
    }
}
