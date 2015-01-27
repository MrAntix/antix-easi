using System;
using Antix.EASI.Data.EF.People.Models;
using Antix.EASI.Domain.People.Patients.Models;

namespace Antix.EASI.Data.EF.People.Patients.Models
{
    public static class PatientMappings
    {
        public static PatientData ToData(
            this CreatePatientModel model)
        {
            if (model == null) throw new ArgumentNullException("model");

            return new PatientData
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
            this PatientData data, UpdatePatientModel model)
        {
            data.Identifier = model.Identifier;
            data.Person.Map(model.Person);
        }
    }
}