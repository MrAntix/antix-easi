using Antix.Services.Validation.Predicates;

namespace Antix.EASI.Domain.Validation
{
    public class DomainValidationPredicates :
        StandardValidationPredicates,
        IDomainValidationPredicates
    {
        readonly IValidationPredicate<string> _stringSmall;
        readonly IValidationPredicate<string> _stringMedium;
        readonly IValidationPredicate<string> _stringLarge;
        readonly IValidationPredicate<string> _stringBlob;

        public DomainValidationPredicates()
        {
            _stringSmall = Length(1, DomainValidationConstants.STRING_SMALL_MAX);
            _stringMedium = Length(1, DomainValidationConstants.STRING_MEDIUM_MAX);
            _stringLarge = Length(1, DomainValidationConstants.STRING_LARGE_MAX);
            _stringBlob = MinLength(1);
        }

        public IValidationPredicate<string> StringSmall
        {
            get { return _stringSmall; }
        }

        public IValidationPredicate<string> StringMedium
        {
            get { return _stringMedium; }
        }

        public IValidationPredicate<string> StringLarge
        {
            get { return _stringLarge; }
        }

        public IValidationPredicate<string> StringBlob
        {
            get { return _stringBlob; }
        }
    }
}