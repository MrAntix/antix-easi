using System;
using Antix.EASI.Domain.People.Models;

namespace Antix.EASI.Domain.People.Clincians.Models
{
    public class UpdateClinicianModel
    {
        public UpdateClinicianModel()
        {
            Person = new UpdatePersonModel();
        }

        public Guid Id { get; set; }
        public string Identifier { get; set; }
        public UpdatePersonModel Person { get; set; }
    }
}