using System;
using Antix.EASI.Domain.People.Models;

namespace Antix.EASI.Domain.People.Patients.Models
{
    public class UpdatePatientModel
    {
        public UpdatePatientModel()
        {
            Person = new UpdatePersonModel();
        }

        public Guid Id { get; set; }
        public string Identifier { get; set; }
        public UpdatePersonModel Person { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public Genders Gender { get; set; }
    }
}