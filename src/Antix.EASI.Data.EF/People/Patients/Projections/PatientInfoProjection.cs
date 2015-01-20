using System;
using System.Linq.Expressions;
using Antix.Data.Projections;
using Antix.EASI.Data.EF.People.Patients.Models;
using Antix.EASI.Domain.People.Clincians.Models;

namespace Antix.EASI.Data.EF.People.Patients.Projections
{
    public class PatientInfoProjection :
        ProjectionBase<PatientData, PatientInfoModel>
    {
        public override Expression<Func<PatientData, PatientInfoModel>> GetExpression()
        {
            return d => new PatientInfoModel
            {
                Id = d.Id,
                Name = d.Person.Name,
                Identifier = d.Identifier
            };
        }
    }
}