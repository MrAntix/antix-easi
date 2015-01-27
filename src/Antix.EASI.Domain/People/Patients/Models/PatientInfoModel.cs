using System;

namespace Antix.EASI.Domain.People.Patients.Models
{
    public class PatientInfoModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Identifier { get; set; }
    }
}