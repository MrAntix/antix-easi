using System;
using Antix.EASI.Api.People.Models;
using Antix.EASI.Domain.People.Models;

namespace Antix.EASI.Api.People.Patients.Models
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string Identifier { get; set; }
        public Person Person { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public Genders Gender { get; set; }
    }
}