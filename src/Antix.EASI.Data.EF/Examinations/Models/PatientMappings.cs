using System;
using Antix.EASI.Domain.Examinations.Models;

namespace Antix.EASI.Data.EF.Examinations.Models
{
    public static class ExaminationMappings
    {
        public static ExaminationData ToData(
            this CreateExaminationModel model)
        {
            if (model == null) throw new ArgumentNullException("model");

            return new ExaminationData
            {
                Id = Guid.NewGuid(),
                ExaminerId = model.ExaminerId,
                PatientId = model.PatientId,
                TakenOn = model.TakenOn
            };
        }
    }
}