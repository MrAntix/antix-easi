using Antix.Services;
using Antix.Services.Validation.Predicates;

namespace Antix.EASI.Domain.Validation
{
    public interface IDomainValidationPredicates :
        IStandardValidationPredicates, IService
    {
        IValidationPredicate<string> StringSmall { get; }
        IValidationPredicate<string> StringMedium { get; }
        IValidationPredicate<string> StringLarge { get; }
        IValidationPredicate<string> StringBlob { get; }
    }
}