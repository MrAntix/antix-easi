using System;
using Antix.EASI.Domain.People.Clincians.Models;
using Antix.EASI.Domain.Validation;
using Antix.Services.Validation;

namespace Antix.EASI.Domain.People.Clincians.Validation
{
    public class CreateClinicianValidator :
        ValidatorBase<CreateClinicianModel, IDomainValidationPredicates>,
        ICreateClinicianValidator
    {
        public CreateClinicianValidator(
            IDomainValidationPredicates @is,
            Func<IValidationRuleBuilder<CreateClinicianModel>> getRulesBuilder) :
                base(@is, getRulesBuilder)
        {
        }

        protected override void Validate(
            IValidationRuleBuilder<CreateClinicianModel> rules)
        {
            rules.For(m => m.Identifier)
                .Assert(Is.NotNull)
                .Assert(Is.StringMedium);

            rules.For(m => m.Name)
                .Assert(Is.NotNull)
                .Assert(Is.StringMedium);
        }
    }
}