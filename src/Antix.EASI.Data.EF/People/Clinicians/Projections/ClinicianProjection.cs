using System;
using System.Linq.Expressions;
using Antix.Data.Projections;
using Antix.EASI.Data.EF.People.Clinicians.Models;
using Antix.EASI.Data.EF.People.Models;
using Antix.EASI.Domain.People.Clincians.Models;
using Antix.EASI.Domain.People.Models;
using LinqKit;

namespace Antix.EASI.Data.EF.People.Clinicians.Projections
{
    public class ClinicianProjection :
        ProjectionBase<ClinicianData, ClinicianModel>
    {
        readonly IProjectionProvider _projectionProvider;

        public ClinicianProjection(
            IProjectionProvider projectionProvider)
        {
            _projectionProvider = projectionProvider;
        }

        public override Expression<Func<ClinicianData, ClinicianModel>> GetExpression()
        {
            var projectPerson = _projectionProvider
                .Get<PersonData, PersonModel>();

            return d => new ClinicianModel
            {
                Id = d.Id,
                Identifier = d.Identifier,
                Person = projectPerson.Invoke(d.Person)
            };
        }
    }
}