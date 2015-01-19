﻿using System;
using System.Data.Entity.ModelConfiguration;
using Antix.Data.Keywords.EF.Entities;
using Antix.EASI.Data.EF.People.Models;

namespace Antix.EASI.Data.EF.People.Clinicians.Models
{
    public class ClinicianData : IndexedEntity
    {
        public ClinicianData()
        {
            Person = new PersonData();
        }

        public Guid Id { get; set; }
        public string Identifier { get; set; }
        public PersonData Person { get; set; }

        public class Configuration :
            EntityTypeConfiguration<ClinicianData>
        {
            public Configuration()
            {
                HasKey(d => d.Id);
            }
        }
    }
}