using System;
using System.Linq.Expressions;
using Antix.EASI.Domain;
using Antix.EASI.Domain.Examinations.Models;

namespace Antix.EASI.Data.EF.Examinations.Models
{
    public static class ExaminationMappings
    {
        public static ExaminationData ToData(
            this CreateExaminationModel model)
        {
            if (model == null) throw new ArgumentNullException("model");

            return new ExaminationData
            {
                Id = Guid.NewGuid(),
                ExaminerId = model.ExaminerId,
                PatientId = model.PatientId,
                TakenOn = model.TakenOn
            };
        }

        public static void TryUpdate(
            this ExaminationData data,
            ExaminationModel model)
        {
            if (model == null) return;
            if (data == null) throw new ArgumentNullException("data");

            if (model.Examiner != null) data.ExaminerId = model.Examiner.Id;
            if (model.Patient != null) data.PatientId = model.Patient.Id;
            data.TakenOn = model.TakenOn;

            data.TryAddOrUpdate(d => d.HeadNeck, model.HeadNeck);
            data.TryAddOrUpdate(d => d.Trunk, model.Trunk);
            data.TryAddOrUpdate(d => d.UpperExtremities, model.UpperExtremities);
            data.TryAddOrUpdate(d => d.LowerExtremities, model.LowerExtremities);

            data.Notes = model.Notes;
        }

        public static void TryAddOrUpdate(
            this ExaminationData examinationData,
            Expression<Func<ExaminationData, ExaminationRegionScoresData>> property,
            ExaminationRegionScoresModel model)
        {
            if (model == null) return;

            var data = property.Get(examinationData);
            if (data == null)
            {
                data = new ExaminationRegionScoresData();
                property.Set(examinationData, data);
            }

            data.TryUpdate(model);
        }

        public static void TryUpdate(
            this ExaminationRegionScoresData data,
            ExaminationRegionScoresModel model)
        {
            if (model == null) return;
            if (data == null) throw new ArgumentNullException("data");

            data.Erthema = model.Erthema;
            data.EdemaPapulation = model.EdemaPapulation;
            data.Excoriation = model.Excoriation;
            data.Lichenification = model.Lichenification;
            data.Area = model.Area;
        }
    }
}