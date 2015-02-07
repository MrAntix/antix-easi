namespace Antix.EASI.Domain.Examinations.Models
{
    public interface IExaminationScoringModel
    {
        ExaminationRegionScoresModel HeadNeck { get; }
        ExaminationRegionScoresModel Trunk { get; }
        ExaminationRegionScoresModel UpperExtremities { get; }
        ExaminationRegionScoresModel LowerExtremities { get; }
    }
}