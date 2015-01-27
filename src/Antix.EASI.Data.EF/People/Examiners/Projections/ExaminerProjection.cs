using System;
using System.Linq.Expressions;
using Antix.Data.Projections;
using Antix.EASI.Data.EF.People.Examiners.Models;
using Antix.EASI.Data.EF.People.Models;
using Antix.EASI.Domain.People.Examiners.Models;
using Antix.EASI.Domain.People.Models;
using LinqKit;

namespace Antix.EASI.Data.EF.People.Examiners.Projections
{
    public class ExaminerProjection :
        ProjectionBase<ExaminerData, ExaminerModel>
    {
        readonly IProjectionProvider _projectionProvider;

        public ExaminerProjection(
            IProjectionProvider projectionProvider)
        {
            _projectionProvider = projectionProvider;
        }

        public override Expression<Func<ExaminerData, ExaminerModel>> GetExpression()
        {
            var projectPerson = _projectionProvider
                .Get<PersonData, PersonModel>();

            return d => new ExaminerModel
            {
                Id = d.Id,
                Identifier = d.Identifier,
                Person = projectPerson.Invoke(d.Person)
            };
        }
    }
}