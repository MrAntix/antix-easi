using System;
using Antix.EASI.Data.EF.People.Models;
using Antix.EASI.Data.EF.People.Patients.Models;
using Antix.EASI.Domain.People.Patients.Models;

namespace Antix.EASI.Data.EF.People.Patients
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
                Person = new PersonData
                {
                    Name = model.Name
                },
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender
            };
        }
    }
}