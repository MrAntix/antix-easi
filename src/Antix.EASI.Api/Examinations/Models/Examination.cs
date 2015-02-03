using System;
using Antix.EASI.Api.People.Examiners.Models;
using Antix.EASI.Api.People.Patients.Models;

namespace Antix.EASI.Api.Examinations.Models
{
    public class Examination
    {
        public Guid Id { get; set; }
        public DateTimeOffset TakenOn { get; set; }
        public ExaminerInfo Examiner { get; set; }
        public PatientInfo Patient { get; set; }

        public ExaminationRegionScores HeadNeck { get; set; }
        public ExaminationRegionScores Trunk { get; set; }
        public ExaminationRegionScores UpperExtremities { get; set; }
        public ExaminationRegionScores LowerExtremities { get; set; }

        public string Notes { get; set; }
    }
}