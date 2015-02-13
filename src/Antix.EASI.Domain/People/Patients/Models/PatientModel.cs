using System;
using Antix.EASI.Domain.People.Models;

namespace Antix.EASI.Domain.People.Patients.Models
{
    public class PatientModel
    {
        public PatientModel()
        {
            Person = new PersonModel();
        }

        public Guid Id { get; set; }
        public string Identifier { get; set; }
        public PersonModel Person { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public Genders Gender { get; set; }
    }
}