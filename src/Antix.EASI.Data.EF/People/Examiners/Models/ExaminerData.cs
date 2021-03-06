﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using Antix.Data.Keywords.EF.Entities;
using Antix.EASI.Data.EF.Examinations.Models;
using Antix.EASI.Data.EF.People.Models;

namespace Antix.EASI.Data.EF.People.Examiners.Models
{
    public class ExaminerData : IndexedEntity
    {
        public ExaminerData()
        {
            Person = new PersonData();
        }

        public Guid Id { get; set; }
        public string Identifier { get; set; }
        public PersonData Person { get; set; }

        public ICollection<ExaminationData> Examinations { get; set; }

        public class Configuration :
            EntityTypeConfiguration<ExaminerData>
        {
            public Configuration()
            {
                HasKey(d => d.Id);
                HasMany(d => d.Keywords)
                    .WithOptional()
                    .WillCascadeOnDelete();

                HasMany(d => d.Examinations)
                    .WithRequired(d => d.Examiner)
                    .HasForeignKey(d => d.ExaminerId)
                    .WillCascadeOnDelete(false);
            }
        }
    }
}