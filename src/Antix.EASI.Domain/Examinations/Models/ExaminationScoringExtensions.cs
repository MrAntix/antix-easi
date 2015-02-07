using System;

namespace Antix.EASI.Domain.Examinations.Models
{
    public static class ExaminationScoringExtensions
    {
        public const decimal HEAD_NECK_MULTIPLIER = .1M;
        public const decimal TRUNK_MULTIPLIER = .3M;
        public const decimal UPPER_EXTREMITIES_MULTIPLIER = .2M;
        public const decimal LOWER_EXTREMITIES_MULTIPLIER = .4M;

        public static bool IsRegionValid(
            this ExaminationRegionScoresModel model)
        {
            return model.Erthema.HasValue
                   && model.EdemaPapulation.HasValue
                   && model.Excoriation.HasValue
                   && model.Lichenification.HasValue
                   && model.Area.HasValue;
        }

        public static int? GetRegionScore(
            this ExaminationRegionScoresModel model,
            decimal multiplier)
        {
            return
                IsRegionValid(model)
                    ? (int) Math.Round(
                        (model.Erthema.Value
                         + model.EdemaPapulation.Value
                         + model.Excoriation.Value
                         + model.Lichenification.Value)*model.Area.Value*multiplier
                        )
                    : default(int?);
        }

        public static ExaminationScoresModel GetScores(
            this IExaminationScoringModel model)
        {
            return  new ExaminationScoresModel
            {
                HeadNeckScore = model.HeadNeck.GetRegionScore(HEAD_NECK_MULTIPLIER),
                TrunkScore = model.Trunk.GetRegionScore(TRUNK_MULTIPLIER),
                UpperExtremitiesScore = model.UpperExtremities.GetRegionScore(UPPER_EXTREMITIES_MULTIPLIER),
                LowerExtremitiesScore = model.LowerExtremities.GetRegionScore(LOWER_EXTREMITIES_MULTIPLIER),
            };
        }
    }
}