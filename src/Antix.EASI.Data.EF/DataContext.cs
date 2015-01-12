using System.Data.Entity;
using Antix.EASI.Data.EF.People;
using Antix.EASI.Data.EF.People.Clinicians.Models;
using Antix.EASI.Data.EF.People.Models;
using Antix.EASI.Data.EF.People.Patients.Models;
using Antix.EASI.Data.EF.Scores.Models;

namespace Antix.EASI.Data.EF
{
    public class DataContext : DbContext
    {
        public IDbSet<PatientData> Patients { get; set; }
        public IDbSet<ClinicianData> Clinicians { get; set; }

        public IDbSet<ScoreData> Scores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations
                .AddFromAssembly(typeof (PersonData).Assembly);
        }

        public const int PERSON_IDENTIFIER_LENGTH = 30;
        public const int NAME_LENGTH = 50;
        public const int NOTES_LENGTH = 500;
    }
}