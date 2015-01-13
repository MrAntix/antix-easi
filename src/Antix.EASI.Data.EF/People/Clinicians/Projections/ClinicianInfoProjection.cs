using System;
using System.Linq.Expressions;
using Antix.Data.Projections;
using Antix.EASI.Data.EF.People.Clinicians.Models;
using Antix.EASI.Domain.People.Clincians.Models;

namespace Antix.EASI.Data.EF.People.Clinicians.Projections
{
    public class ClinicianInfoProjection:
        ProjectionBase<ClinicianData,ClinicianInfoModel>
    {
        public override Expression<Func<ClinicianData, ClinicianInfoModel>> GetExpression()
        {
            return d => new ClinicianInfoModel
            {
                Id = d.Id,
                Name = d.Person.Name
            };
        }
    }
}