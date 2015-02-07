using System;
using Antix.EASI.Api.People.Examiners.Models;
using Antix.EASI.Api.People.Patients.Models;

namespace Antix.EASI.Api.Examinations.Models
{
    public class ExaminationInfo
    {
        public Guid Id { get; set; }
        public DateTimeOffset TakenOn { get; set; }
        public ExaminerInfo Examiner { get; set; }
        public PatientInfo Patient { get; set; }

        public int? HeadNeckScore { get; set; }
        public int? TrunkScore { get; set; }
        public int? UpperExtremitiesScore { get; set; }
        public int? LowerExtremitiesScore { get; set; }
        public int? TotalScore { get; set; }
    }
}