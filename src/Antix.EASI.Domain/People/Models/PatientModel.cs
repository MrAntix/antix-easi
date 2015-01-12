using System;

namespace Antix.EASI.Domain.People.Models
{
    public class PatientModel
    {
        public PatientModel()
        {
            Person = new PersonModel();
        }

        public Guid Id { get; set; }
        public PersonModel Person { get; set; }

        public string Reference { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public Genders Gender { get; set; }
    }
}