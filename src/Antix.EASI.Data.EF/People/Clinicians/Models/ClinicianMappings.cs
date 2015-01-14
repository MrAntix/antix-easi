using System;
using Antix.EASI.Data.EF.People.Models;
using Antix.EASI.Domain.People.Clincians.Models;

namespace Antix.EASI.Data.EF.People.Clinicians.Models
{
    public static class ClinicianMappings
    {
        public static ClinicianData ToData(
            this CreateClinicianModel model)
        {
            if (model == null) throw new ArgumentNullException("model");

            return new ClinicianData
            {
                Id = Guid.NewGuid(),
                Identifier = model.Identifier,
                Person = new PersonData
                {
                    Name = model.Name
                }
            };
        }

        public static void Map(
            this ClinicianData data, UpdateClinicianModel model)
        {
            data.Identifier = model.Identifier;
            data.Person.Map(model.Person);
        }
    }
}