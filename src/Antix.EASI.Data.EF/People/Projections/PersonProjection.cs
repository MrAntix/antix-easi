using System;
using System.Linq.Expressions;
using Antix.Data.Projections;
using Antix.EASI.Data.EF.People.Models;
using Antix.EASI.Domain.People.Models;

namespace Antix.EASI.Data.EF.People.Projections
{
    public class PersonProjection :
        ProjectionBase<PersonData, PersonModel>
    {
        public override Expression<Func<PersonData, PersonModel>> GetExpression()
        {
            return d => new PersonModel
            {
                Name = d.Name
            };
        }
    }
}