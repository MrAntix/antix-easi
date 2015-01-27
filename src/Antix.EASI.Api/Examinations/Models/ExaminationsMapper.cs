using Antix.EASI.Domain.Examinations.Models;

namespace Antix.EASI.Api.Examinations.Models
{
    public static class ExaminationsMapper
    {
        public static CreateExaminationModel ToModel(
            this CreateExamination contract)
        {
            if (contract == null) return null;

            return new CreateExaminationModel
            {
                ExaminerId = contract.ExaminerId,
                PatientId = contract.PatientId,
                TakenOn = contract.TakenOn
            };
        }
    }
}