﻿using System;
using System.Data.Entity.ModelConfiguration;
using Antix.Data.Keywords.EF.Entities;
using Antix.EASI.Data.EF.People.Models;

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

        public class Configuration :
            EntityTypeConfiguration<PatientData>
        {
            public Configuration()
            {
                HasKey(d => d.Id);
                HasMany(d => d.Keywords)
                    .WithOptional()
                    .WillCascadeOnDelete();
            }
        }
    }
}