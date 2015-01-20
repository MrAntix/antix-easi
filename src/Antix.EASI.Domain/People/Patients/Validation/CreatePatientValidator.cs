using System;
using Antix.EASI.Domain.People.Clincians.Models;
using Antix.EASI.Domain.Validation;
using Antix.Services.Validation;

namespace Antix.EASI.Domain.People.Clincians.Validation
{
    public class CreatePatientValidator :
        ValidatorBase<CreatePatientModel, IDomainValidationPredicates>,
        ICreatePatientValidator
    {
        public CreatePatientValidator(
            IDomainValidationPredicates @is,
            Func<IValidationRuleBuilder<CreatePatientModel>> getRulesBuilder) :
                base(@is, getRulesBuilder)
        {
        }

        protected override void Validate(
            IValidationRuleBuilder<CreatePatientModel> rules)
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