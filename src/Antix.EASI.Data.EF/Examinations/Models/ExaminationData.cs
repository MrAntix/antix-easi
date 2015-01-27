using System;
using System.Data.Entity.ModelConfiguration;
using Antix.EASI.Data.EF.People.Examiners.Models;
using Antix.EASI.Data.EF.People.Patients.Models;

namespace Antix.EASI.Data.EF.Examinations.Models
{
    public class ExaminationData
    {
        public ExaminationData()
        {
            HeadNeck = new ExaminationRegionScoresData();
            Trunk = new ExaminationRegionScoresData();
            UpperExtremities = new ExaminationRegionScoresData();
            LowerExtremities = new ExaminationRegionScoresData();
        }

        public Guid Id { get; set; }

        public Guid ExaminerId { get; set; }
        public ExaminerData Examiner { get; set; }

        public Guid PatientId { get; set; }
        public PatientData Patient { get; set; }

        public DateTimeOffset TakenOn { get; set; }

        public ExaminationRegionScoresData HeadNeck { get; set; }
        public ExaminationRegionScoresData Trunk { get; set; }
        public ExaminationRegionScoresData UpperExtremities { get; set; }
        public ExaminationRegionScoresData LowerExtremities { get; set; }

        public string Notes { get; set; }

        public class Configuration :
            EntityTypeConfiguration<ExaminationData>
        {
            public Configuration()
            {
                HasKey(d => d.Id);
                Property(d => d.Notes)
                    .HasMaxLength(DataContext.NOTES_LENGTH);
            }
        }
    }
}