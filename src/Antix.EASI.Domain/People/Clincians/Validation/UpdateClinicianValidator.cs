using System;
using Antix.EASI.Domain.People.Clincians.Models;
using Antix.EASI.Domain.People.Validation;
using Antix.EASI.Domain.Validation;
using Antix.Services.Validation;

namespace Antix.EASI.Domain.People.Clincians.Validation
{
    public class UpdateClinicianValidator :
        ValidatorBase<UpdateClinicianModel, IDomainValidationPredicates>,
        IUpdateClinicianValidator
    {
        readonly IUpdatePersonValidator _personValidator;

        public UpdateClinicianValidator(
            IDomainValidationPredicates @is, 
            Func<IValidationRuleBuilder<UpdateClinicianModel>> getRulesBuilder, IUpdatePersonValidator personValidator) :
                base(@is, getRulesBuilder)
        {
            _personValidator = personValidator;
        }

        protected override void Validate(
            IValidationRuleBuilder<UpdateClinicianModel> rules)
        {
            rules.For(m => m.Identifier)
                .Assert(Is.NotNull)
                .Assert(Is.StringMedium);

            rules.For(m => m.Person)
                .Validate(_personValidator);
        }
    }
}