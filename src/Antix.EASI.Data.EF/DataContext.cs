using System.Data.Entity;
using System.Threading.Tasks;
using Antix.Data.Keywords.EF;
using Antix.EASI.Data.EF.People.Clinicians.Models;
using Antix.EASI.Data.EF.People.Models;
using Antix.EASI.Data.EF.Scores.Models;

namespace Antix.EASI.Data.EF
{
    public class DataContext : DbContext
    {
        private readonly EFKeywordsManager _keywordsManager;

        public DataContext(EFKeywordsManager keywordsManager)
        {
            _keywordsManager = keywordsManager;
        }

        // Required by migrations
        public DataContext()
            : this(null)
        {
        }

       // public IDbSet<PatientData> Patients { get; set; }
        public IDbSet<ClinicianData> Clinicians { get; set; }

        public IDbSet<ScoreData> Scores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations
                .AddFromAssembly(typeof(PersonData).Assembly);
        }

        public const int PERSON_IDENTIFIER_LENGTH = 30;
        public const int NAME_LENGTH = 50;
        public const int NOTES_LENGTH = 500;

        public override int SaveChanges()
        {
            _keywordsManager.UpdateKeywordsAsync(this).Wait();

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync()
        {
            await _keywordsManager.UpdateKeywordsAsync(this);
            
            return await base.SaveChangesAsync();
        }
    }
}