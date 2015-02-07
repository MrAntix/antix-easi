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

        public static int? GetRegionScoreBeforeMultiplier(
            this ExaminationRegionScoresModel model)
        {
            return
                IsRegionValid(model)
                    ? (model.Erthema.Value
                       + model.EdemaPapulation.Value
                       + model.Excoriation.Value
                       + model.Lichenification.Value)*model.Area.Value
                    : default(int?);
        }

        public static int? GetRegionScore(
            this ExaminationRegionScoresModel model,
            decimal multiplier)
        {
            return
                IsRegionValid(model)
                    ? (int) Math.Round(
                        GetRegionScoreBeforeMultiplier(model).Value*multiplier)
                    : default(int?);
        }

        public static int? GetRegionScorePercent(
            this ExaminationRegionScoresModel model)
        {
            return
                IsRegionValid(model)
                    ? (int) Math.Round(
                        GetRegionScoreBeforeMultiplier(model).Value/7.2)
                    : default(int?);
        }

        public static int? GetTotalScore(
            this IExaminationScoringModel model)
        {
            return model.HeadNeck.GetRegionScore(HEAD_NECK_MULTIPLIER)
                   + model.Trunk.GetRegionScore(TRUNK_MULTIPLIER)
                   + model.UpperExtremities.GetRegionScore(UPPER_EXTREMITIES_MULTIPLIER)
                   + model.LowerExtremities.GetRegionScore(LOWER_EXTREMITIES_MULTIPLIER);
        }

        public static ExaminationScoresModel GetScores(
            this IExaminationScoringModel model)
        {
            return new ExaminationScoresModel
            {
                HeadNeckScorePercent = model.HeadNeck.GetRegionScorePercent(),
                TrunkScorePercent = model.Trunk.GetRegionScorePercent(),
                UpperExtremitiesScorePercent = model.UpperExtremities.GetRegionScorePercent(),
                LowerExtremitiesScorePercent = model.LowerExtremities.GetRegionScorePercent(),
                TotalScore = model.GetTotalScore()
            };
        }
    }
}