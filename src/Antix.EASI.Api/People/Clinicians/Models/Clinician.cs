using System;
using Antix.EASI.Api.People.Models;

namespace Antix.EASI.Api.People.Clinicians.Models
{
    public class Clinician
    {
        public Guid Id { get; set; }
        public string Identifier { get; set; }
        public Person Person { get; set; }
    }
}