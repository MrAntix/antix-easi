using System;
using Antix.EASI.Data.EF.People.Clinicians.Models;
using Antix.EASI.Data.EF.People.Models;
using Antix.EASI.Domain.People.Clincians.Models;

namespace Antix.EASI.Data.EF.People.Clinicians
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
                Person = new PersonData
                {
                    Name = model.Name
                }
            };
        }
    }
}