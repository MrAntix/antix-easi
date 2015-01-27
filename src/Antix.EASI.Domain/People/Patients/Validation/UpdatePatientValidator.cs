using System;
using Antix.EASI.Domain.People.Patients.Models;
using Antix.EASI.Domain.People.Validation;
using Antix.EASI.Domain.Validation;
using Antix.Services.Validation;

namespace Antix.EASI.Domain.People.Patients.Validation
{
    public class UpdatePatientValidator :
        ValidatorBase<UpdatePatientModel, IDomainValidationPredicates>,
        IUpdatePatientValidator
    {
        readonly IUpdatePersonValidator _personValidator;

        public UpdatePatientValidator(
            IDomainValidationPredicates @is,
            Func<IValidationRuleBuilder<UpdatePatientModel>> getRulesBuilder, IUpdatePersonValidator personValidator) :
                base(@is, getRulesBuilder)
        {
            _personValidator = personValidator;
        }

        protected override void Validate(
            IValidationRuleBuilder<UpdatePatientModel> rules)
        {
            rules.For(m => m.Identifier)
                .Assert(Is.NotNull)
                .Assert(Is.StringMedium);

            rules.For(m => m.Person)
                .Validate(_personValidator);
        }
    }
}