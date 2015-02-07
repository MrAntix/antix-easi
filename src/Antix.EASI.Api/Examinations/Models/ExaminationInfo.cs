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

        public int? HeadNeckScorePercent { get; set; }
        public int? TrunkScorePercent { get; set; }
        public int? UpperExtremitiesScorePercent { get; set; }
        public int? LowerExtremitiesScorePercent { get; set; }
        public int? TotalScore { get; set; }

        public string Notes { get; set; }
    }
}