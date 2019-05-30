using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog.Domain.Validation
{

    public class ValidationService: IValidationService
    {
        private readonly IValidatorFactory _factory;
        public ValidationService(IValidatorFactory factory)
        {
            _factory = factory;
        }

        public async Task Validate<T>(T request) {

            var context = new ValidationContext(request);

            var validator = _factory.GetValidator<T>();

            var result = validator.Validate(context);

            if (result.Errors.Any())
                throw new System.Exception(
                    $"Command Validation Errors for type {typeof(T).Name}",
                    new ValidationException("ValidationException", result.Errors));

        }
    }
}
