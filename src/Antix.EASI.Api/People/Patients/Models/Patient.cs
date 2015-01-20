using System;
using Antix.EASI.Api.People.Models;

namespace Antix.EASI.Api.People.Patients.Models
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string Identifier { get; set; }
        public Person Person { get; set; }
    }
}