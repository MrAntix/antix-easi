using System;
using Antix.EASI.Domain.People.Examiners.Models;
using Antix.EASI.Domain.People.Patients.Models;

namespace Antix.EASI.Domain.Examinations.Models
{
    public class ExaminationModel
    {
        public Guid Id { get; set; }

        public DateTimeOffset TakenOn { get; set; }
        public ExaminerInfoModel Examiner { get; set; }
        public PatientInfoModel Patient { get; set; }
    }
}