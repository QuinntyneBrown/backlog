using FluentValidation;
using System;


namespace Backlog.Domain.Validation;

public interface IValidatorFactory
{
    IValidator<T> GetValidator<T>();
    IValidator GetValidator(Type type);
}
