using System;
using System.Data.Entity.ModelConfiguration;
using Antix.EASI.Data.EF.People.Models;
using Antix.EASI.Domain;
using Antix.EASI.Domain.People.Models;
using Antix.EASI.Domain.Validation;

namespace Antix.EASI.Data.EF.People.Patients.Models
{
    public class PatientData
    {
        public PatientData()
        {
            Person = new PersonData();
        }

        public Guid Id { get; set; }
        public PersonData Person { get; set; }

        public string Identifier { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public Genders Gender { get; set; }

        public class Configuration :
            EntityTypeConfiguration<PatientData>
        {
            public Configuration()
            {
                HasKey(d => d.Id);
                Property(d => d.Identifier)
                    .HasMaxLength(DomainValidationConstants.STRING_MEDIUM_MAX);
            }
        }
    }
}