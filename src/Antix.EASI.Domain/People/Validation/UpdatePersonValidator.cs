using System;
using Antix.EASI.Domain.People.Models;
using Antix.EASI.Domain.Validation;
using Antix.Services.Validation;

namespace Antix.EASI.Domain.People.Validation
{
    public class UpdatePersonValidator :
        ValidatorBase<UpdatePersonModel, IDomainValidationPredicates>,
        IUpdatePersonValidator
    {
        public UpdatePersonValidator(
            IDomainValidationPredicates @is, Func<IValidationRuleBuilder<UpdatePersonModel>> getRulesBuilder) :
                base(@is, getRulesBuilder)
        {
        }

        protected override void Validate(
            IValidationRuleBuilder<UpdatePersonModel> rules)
        {
            rules.For(m => m.Name)
                .Assert(Is.NotNull)
                .Assert(Is.StringMedium);
        }
    }
}