using System;
using Antix.EASI.Domain.Examinations.Models;
using Antix.EASI.Domain.Validation;
using Antix.Services.Validation;

namespace Antix.EASI.Domain.Examinations.Validation
{
    public class UpdateExaminationValidator :
        ValidatorBase<UpdateExaminationModel, IDomainValidationPredicates>,
        IUpdateExaminationValidator
    {
        public UpdateExaminationValidator(
            IDomainValidationPredicates @is, 
            Func<IValidationRuleBuilder<UpdateExaminationModel>> getRulesBuilder) : 
                base(@is, getRulesBuilder)
        {
        }

        protected override void Validate(IValidationRuleBuilder<UpdateExaminationModel> rules)
        {
            throw new NotImplementedException();
        }
    }
}