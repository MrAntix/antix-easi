using System;
using System.Data.Entity.Migrations;
using Antix.EASI.Data.EF.People.Examiners.Models;
using Antix.EASI.Data.EF.People.Models;
using Antix.EASI.Data.EF.People.Patients.Models;

namespace Antix.EASI.Data.EF.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataContext context)
        {
            var examinerId = new Guid("AE39D145-433C-4252-8242-6A482240049B");
            var patiendId = new Guid("A1C5F3CE-1FCA-4C3D-AAF2-0D3E8725E4BD");

            context
                .Examiners.AddOrUpdate(
                    d => d.Id,
                    new ExaminerData
                    {
                        Id = examinerId,
                        Identifier = "AE",
                        Person = new PersonData
                        {
                            Name = "An Examiner"
                        }
                    });

            context
                .Patients.AddOrUpdate(
                    d => d.Id,
                    new PatientData
                    {
                        Id = patiendId,
                        Identifier = "AP",
                        Person = new PersonData
                        {
                            Name = "A Patient"
                        }
                    });

            context.SaveChanges();
        }
    }
}