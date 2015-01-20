using System;
using Antix.EASI.Domain.People.Clincians.Models;
using Antix.EASI.Domain.People.Models;

namespace Antix.EASI.Domain.Scores.Models
{
    public class ScoreModel
    {
        public ScoreModel()
        {
            HeadNeck = new ScoreRegionModel();
            Trunk = new ScoreRegionModel();
            UpperExtremities = new ScoreRegionModel();
            LowerExtremities = new ScoreRegionModel();
        }

        public Guid Id { get; set; }
        public ExaminerModel Examiner { get; set; }
        public PatientModel Patient { get; set; }

        public DateTimeOffset TakenOn { get; set; }

        public ScoreRegionModel HeadNeck { get;  set; }
        public ScoreRegionModel Trunk { get; set; }
        public ScoreRegionModel UpperExtremities { get; set; }
        public ScoreRegionModel LowerExtremities { get; set; }

        public string Notes { get; set; }

    }
}