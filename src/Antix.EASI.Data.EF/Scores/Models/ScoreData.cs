using System;
using System.Data.Entity.ModelConfiguration;
using Antix.EASI.Data.EF.People.Clinicians.Models;

namespace Antix.EASI.Data.EF.Scores.Models
{
    public class ScoreData
    {
        public ScoreData()
        {
            HeadNeck = new ScoreRegionData();
            Trunk = new ScoreRegionData();
            UpperExtremities = new ScoreRegionData();
            LowerExtremities = new ScoreRegionData();
        }

        public Guid Id { get; set; }
        public ClinicianData Clinician { get; set; }
        //public PatientData Patient { get; set; }

        public DateTimeOffset TakenOn { get; set; }

        public ScoreRegionData HeadNeck { get; set; }
        public ScoreRegionData Trunk { get; set; }
        public ScoreRegionData UpperExtremities { get; set; }
        public ScoreRegionData LowerExtremities { get; set; }

        public string Notes { get; set; }

        public class Configuration :
            EntityTypeConfiguration<ScoreData>
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