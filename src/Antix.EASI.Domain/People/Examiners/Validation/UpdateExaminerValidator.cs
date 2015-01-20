using System;
using Antix.EASI.Domain.People.Clincians.Models;
using Antix.EASI.Domain.People.Validation;
using Antix.EASI.Domain.Validation;
using Antix.Services.Validation;

namespace Antix.EASI.Domain.People.Clincians.Validation
{
    public class UpdateExaminerValidator :
        ValidatorBase<UpdateExaminerModel, IDomainValidationPredicates>,
        IUpdateExaminerValidator
    {
        readonly IUpdatePersonValidator _personValidator;

        public UpdateExaminerValidator(
            IDomainValidationPredicates @is, 
            Func<IValidationRuleBuilder<UpdateExaminerModel>> getRulesBuilder, IUpdatePersonValidator personValidator) :
                base(@is, getRulesBuilder)
        {
            _personValidator = personValidator;
        }

        protected override void Validate(
            IValidationRuleBuilder<UpdateExaminerModel> rules)
        {
            rules.For(m => m.Identifier)
                .Assert(Is.NotNull)
                .Assert(Is.StringMedium);

            rules.For(m => m.Person)
                .Validate(_personValidator);
        }
    }
}