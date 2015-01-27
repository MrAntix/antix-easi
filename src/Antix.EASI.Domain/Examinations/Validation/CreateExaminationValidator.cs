using System;
using Antix.EASI.Domain.Examinations.Models;
using Antix.EASI.Domain.People.Examiners.Validation.Predicates;
using Antix.EASI.Domain.People.Patients.Validation.Predicates;
using Antix.EASI.Domain.Validation;
using Antix.Services.Validation;

namespace Antix.EASI.Domain.Examinations.Validation
{
    public class CreateExaminationValidator :
        ValidatorBase<CreateExaminationModel, IDomainValidationPredicates>,
        ICreateExaminationValidator
    {
        readonly IExaminerExistsPredicate _examinerExists;
        readonly IPatientExistsPredicate _patientExists;

        public CreateExaminationValidator(
            IExaminerExistsPredicate examinerExists,
            IPatientExistsPredicate patientExists,
            IDomainValidationPredicates @is,
            Func<IValidationRuleBuilder<CreateExaminationModel>> getRulesBuilder) :
                base(@is, getRulesBuilder)
        {
            _examinerExists = examinerExists;
            _patientExists = patientExists;
        }

        protected override void Validate(
            IValidationRuleBuilder<CreateExaminationModel> rules)
        {
            rules.For(m => m.ExaminerId)
                .Assert(_examinerExists);

            rules.For(m => m.PatientId)
                .Assert(_patientExists);

            rules.For(m => m.TakenOn)
                .Assert(Is.Max(DateTimeOffset.UtcNow));
        }
    }
}