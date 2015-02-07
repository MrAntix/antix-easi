using System;
using Antix.EASI.Domain.People.Examiners.Models;
using Antix.EASI.Domain.People.Patients.Models;

namespace Antix.EASI.Domain.Examinations.Models
{
    public class ExaminationInfoModel : IExaminationScoringModel
    {
        public Guid Id { get; set; }
        public DateTimeOffset TakenOn { get; set; }
        public ExaminerInfoModel Examiner { get; set; }
        public PatientInfoModel Patient { get; set; }

        public ExaminationRegionScoresModel HeadNeck { get; set; }
        public ExaminationRegionScoresModel Trunk { get; set; }
        public ExaminationRegionScoresModel UpperExtremities { get; set; }
        public ExaminationRegionScoresModel LowerExtremities { get; set; }

        public ExaminationScoresModel Scores { get { return this.GetScores(); } }
    }
}