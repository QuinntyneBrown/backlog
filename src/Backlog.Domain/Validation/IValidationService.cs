using System.Threading.Tasks;


namespace Backlog.Domain.Validation;

public interface IValidationService
{
    Task Validate<T>(T request);
}
