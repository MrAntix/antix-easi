using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using Antix.Data.Keywords.EF.Entities;
using Antix.EASI.Data.EF.Examinations.Models;
using Antix.EASI.Data.EF.People.Models;
using Antix.EASI.Domain.People.Models;

namespace Antix.EASI.Data.EF.People.Patients.Models
{
    public class PatientData : IndexedEntity
    {
        public PatientData()
        {
            Person = new PersonData();
        }

        public Guid Id { get; set; }
        public string Identifier { get; set; }
        public PersonData Person { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public Genders Gender { get; set; }

        public ICollection<ExaminationData> Examinations { get; set; }

        public class Configuration :
            EntityTypeConfiguration<PatientData>
        {
            public Configuration()
            {
                HasKey(d => d.Id);
                HasMany(d => d.Keywords)
                    .WithOptional()
                    .WillCascadeOnDelete();

                HasMany(d => d.Examinations)
                    .WithRequired(d => d.Patient)
                    .HasForeignKey(d => d.PatientId)
                    .WillCascadeOnDelete(false);
            }
        }
    }
}