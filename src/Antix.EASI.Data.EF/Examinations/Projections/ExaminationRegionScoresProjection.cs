using System;
using System.Linq.Expressions;
using Antix.Data.Projections;
using Antix.EASI.Data.EF.Examinations.Models;
using Antix.EASI.Domain.Examinations.Models;

namespace Antix.EASI.Data.EF.Examinations.Projections
{
    public class ExaminationRegionScoresProjection :
        ProjectionBase<ExaminationRegionScoresData, ExaminationRegionScoresModel>
    {
        public override Expression<Func<ExaminationRegionScoresData, ExaminationRegionScoresModel>> GetExpression()
        {
            return d => new ExaminationRegionScoresModel
            {
                Erthema = d.Erthema,
                EdemaPapulation = d.EdemaPapulation,
                Excoriation = d.Excoriation,
                Lichenification = d.Lichenification,
                Area = d.Area
            };
        }
    }
}