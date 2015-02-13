using System;
using Antix.EASI.Domain.People.Models;

namespace Antix.EASI.Api.People.Patients.Models
{
    public class CreatePatient
    {
        public string Identifier { get; set; }
        public string Name { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public Genders Gender { get; set; }
    }
}