using System.Collections.Generic;
using System.Linq;
using Antix.EASI.Api.People.Examiners.Models;
using Antix.EASI.Api.People.Patients.Models;
using Antix.EASI.Domain.Examinations.Models;

namespace Antix.EASI.Api.Examinations.Models
{
    public static class ExaminationsMapper
    {
        public static ExaminationInfo ToContract(
            this ExaminationInfoModel model)
        {
            if (model == null) return null;

            return new ExaminationInfo
            {
                Id = model.Id,
                TakenOn = model.TakenOn,
                Examiner = model.Examiner.ToContract(),
                Patient = model.Patient.ToContract(),
                HeadNeckScorePercent = model.Scores.HeadNeckScorePercent,
                TrunkScorePercent = model.Scores.TrunkScorePercent,
                UpperExtremitiesScorePercent = model.Scores.UpperExtremitiesScorePercent,
                LowerExtremitiesScorePercent = model.Scores.LowerExtremitiesScorePercent,
                TotalScore = model.Scores.TotalScore,
                Notes = model.Notes
            };
        }

        public static ExaminationInfo[] ToContract(
            this IEnumerable<ExaminationInfoModel> models)
        {
            if (models == null) return null;

            return models.Select(m => m.ToContract()).ToArray();
        }

        public static Examination ToContract(
            this ExaminationModel model)
        {
            if (model == null) return null;

            return new Examination
            {
                Id = model.Id,
                TakenOn = model.TakenOn,
                Examiner = model.Examiner.ToContract(),
                Patient = model.Patient.ToContract(),
                HeadNeck = model.HeadNeck.ToContract(),
                Trunk = model.Trunk.ToContract(),
                UpperExtremities = model.UpperExtremities.ToContract(),
                LowerExtremities = model.LowerExtremities.ToContract(),
                Notes = model.Notes
            };
        }

        public static ExaminationRegionScores ToContract(
            this ExaminationRegionScoresModel model)
        {
            if (model == null) return null;

            return new ExaminationRegionScores
            {
                Erthema = model.Erthema,
                EdemaPapulation = model.EdemaPapulation,
                Excoriation = model.Excoriation,
                Lichenification = model.Lichenification,
                Area = model.Area
            };
        }

        public static LookupExaminationsModel ToModel(
            this LookupExaminations contract)
        {
            if (contract == null) return null;

            return new LookupExaminationsModel
            {
                Text = contract.Text,
                DateFrom = contract.DateFrom,
                DateTo = contract.DateTo,
                Index = contract.Index,
                Count = contract.Count
            };
        }

        public static CreateExaminationModel ToModel(
            this CreateExamination contract)
        {
            if (contract == null) return null;

            return new CreateExaminationModel
            {
                ExaminerId = contract.ExaminerId,
                PatientId = contract.PatientId,
                TakenOn = contract.TakenOn
            };
        }

        public static ExaminationModel ToModel(
            this Examination contract)
        {
            if (contract == null) return null;

            return new ExaminationModel
            {
                Id = contract.Id,
                TakenOn = contract.TakenOn,
                HeadNeck = contract.HeadNeck.ToModel(),
                Trunk = contract.Trunk.ToModel(),
                UpperExtremities = contract.UpperExtremities.ToModel(),
                LowerExtremities = contract.LowerExtremities.ToModel(),
                Notes = contract.Notes
            };
        }


        public static ExaminationRegionScoresModel ToModel(
            this ExaminationRegionScores contract)
        {
            if (contract == null) return null;

            return new ExaminationRegionScoresModel
            {
                Erthema = contract.Erthema,
                EdemaPapulation = contract.EdemaPapulation,
                Excoriation = contract.Excoriation,
                Lichenification = contract.Lichenification,
                Area = contract.Area
            };
        }
    }
}