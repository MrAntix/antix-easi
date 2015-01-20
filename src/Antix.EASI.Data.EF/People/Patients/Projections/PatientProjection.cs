using System;
using System.Linq.Expressions;
using Antix.Data.Projections;
using Antix.EASI.Data.EF.People.Patients.Models;
using Antix.EASI.Data.EF.People.Models;
using Antix.EASI.Domain.People.Clincians.Models;
using Antix.EASI.Domain.People.Models;
using LinqKit;

namespace Antix.EASI.Data.EF.People.Patients.Projections
{
    public class PatientProjection :
        ProjectionBase<PatientData, PatientModel>
    {
        readonly IProjectionProvider _projectionProvider;

        public PatientProjection(
            IProjectionProvider projectionProvider)
        {
            _projectionProvider = projectionProvider;
        }

        public override Expression<Func<PatientData, PatientModel>> GetExpression()
        {
            var projectPerson = _projectionProvider
                .Get<PersonData, PersonModel>();

            return d => new PatientModel
            {
                Id = d.Id,
                Identifier = d.Identifier,
                Person = projectPerson.Invoke(d.Person)
            };
        }
    }
}