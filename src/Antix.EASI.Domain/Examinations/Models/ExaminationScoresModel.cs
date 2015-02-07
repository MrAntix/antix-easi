namespace Antix.EASI.Domain.Examinations.Models
{
    public class ExaminationScoresModel
    {
        public int? HeadNeckScore { get; set; }
        public int? TrunkScore { get; set; }
        public int? UpperExtremitiesScore { get; set; }
        public int? LowerExtremitiesScore { get; set; }

        public int? TotalScore
        {
            get
            {
                return HeadNeckScore
                       + TrunkScore
                       + UpperExtremitiesScore
                       + LowerExtremitiesScore;
            }
        }
    }
}