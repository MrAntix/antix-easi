namespace Antix.EASI.Domain.Examinations.Models
{
    public class ExaminationScoresModel
    {
        public int? HeadNeckScorePercent { get; set; }
        public int? TrunkScorePercent { get; set; }
        public int? UpperExtremitiesScorePercent { get; set; }
        public int? LowerExtremitiesScorePercent { get; set; }

        public int? TotalScore { get; set; }
    }
}