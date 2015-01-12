using System;
using Antix.EASI.Domain.People.Models;

namespace Antix.EASI.Domain.People.Clincians.Models
{
    public class ClinicianModel
    {
        public ClinicianModel()
        {
            Person = new PersonModel();
        }

        public Guid Id { get; set; }
        public PersonModel Person { get; set; }
    }
}