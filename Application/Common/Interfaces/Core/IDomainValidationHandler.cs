using ValidationResult = Domain.Common.ValidationResult;

namespace Application.Common.Interfaces.Core;

public interface IDomainValidationHandler { }

public interface IDomainValidationHandler<T> : IDomainValidationHandler
{
    Task<ValidationResult> Validate(T request);
}