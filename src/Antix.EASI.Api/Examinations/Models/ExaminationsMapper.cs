using System.Collections.Generic;
using System.Linq;
using Antix.EASI.Api.People.Examiners.Models;
using Antix.EASI.Api.People.Patients.Models;
using Antix.EASI.Domain.Examinations.Models;

namespace Antix.EASI.Api.Examinations.Models
{
    public static class ExaminationsMapper
    {
        public static ExaminationInfo ToContract(
            this ExaminationInfoModel model)
        {
            if (model == null) return null;

            return new ExaminationInfo
            {
                Id = model.Id,
                TakenOn = model.TakenOn,
                Examiner = model.Examiner.ToContract(),
                Patient = model.Patient.ToContract()
            };
        }

        public static ExaminationInfo[] ToContract(
            this IEnumerable<ExaminationInfoModel> models)
        {
            if (models == null) return null;

            return models.Select(m => m.ToContract()).ToArray();
        }


        public static LookupExaminationsModel ToModel(
            this LookupExaminations contract)
        {
            if (contract == null) return null;

            return new LookupExaminationsModel
            {
                Text = contract.Text,
                Index = contract.Index,
                Count = contract.Count
            };
        }

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