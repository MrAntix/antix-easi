using System;
using Antix.EASI.Domain.People.Examiners.Models;
using Antix.EASI.Domain.Validation;
using Antix.Services.Validation;

namespace Antix.EASI.Domain.People.Examiners.Validation
{
    public class CreateExaminerValidator :
        ValidatorBase<CreateExaminerModel, IDomainValidationPredicates>,
        ICreateExaminerValidator
    {
        public CreateExaminerValidator(
            IDomainValidationPredicates @is,
            Func<IValidationRuleBuilder<CreateExaminerModel>> getRulesBuilder) :
                base(@is, getRulesBuilder)
        {
        }

        protected override void Validate(
            IValidationRuleBuilder<CreateExaminerModel> rules)
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