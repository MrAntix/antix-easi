using System;
using System.Linq.Expressions;
using Antix.Data.Projections;
using Antix.EASI.Data.EF.People.Examiners.Models;
using Antix.EASI.Domain.People.Clincians.Models;

namespace Antix.EASI.Data.EF.People.Examiners.Projections
{
    public class ExaminerInfoProjection :
        ProjectionBase<ExaminerData, ExaminerInfoModel>
    {
        public override Expression<Func<ExaminerData, ExaminerInfoModel>> GetExpression()
        {
            return d => new ExaminerInfoModel
            {
                Id = d.Id,
                Name = d.Person.Name,
                Identifier = d.Identifier
            };
        }
    }
}