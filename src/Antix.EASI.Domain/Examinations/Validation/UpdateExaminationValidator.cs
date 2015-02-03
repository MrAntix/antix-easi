using System;
using Antix.EASI.Domain.Examinations.Models;
using Antix.EASI.Domain.People.Examiners.Validation.Predicates;
using Antix.EASI.Domain.People.Patients.Validation.Predicates;
using Antix.EASI.Domain.Validation;
using Antix.Services.Validation;

namespace Antix.EASI.Domain.Examinations.Validation
{
    public class UpdateExaminationValidator :
        ValidatorBase<ExaminationModel, IDomainValidationPredicates>,
        IUpdateExaminationValidator
    {
        readonly IExaminerExistsPredicate _examinerExists;
        readonly IPatientExistsPredicate _patientExists;

        public UpdateExaminationValidator(
            IExaminerExistsPredicate examinerExists,
            IPatientExistsPredicate patientExists,
            IDomainValidationPredicates @is,
            Func<IValidationRuleBuilder<ExaminationModel>> getRulesBuilder) :
                base(@is, getRulesBuilder)
        {
            _examinerExists = examinerExists;
            _patientExists = patientExists;
        }

        protected override void Validate(
            IValidationRuleBuilder<ExaminationModel> rules)
        {
            rules
                .When(m => m.Examiner != null)
                .For(m => m.Examiner.Id)
                .Assert(_examinerExists);

            rules
                .When(m => m.Patient != null)
                .For(m => m.Patient.Id)
                .Assert(_patientExists);

            rules.For(m => m.TakenOn)
                .Assert(Is.Range(DateTimeOffset.UtcNow.AddYears(-100), DateTimeOffset.UtcNow));
        }
    }
}