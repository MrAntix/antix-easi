using System.Data.Entity;
using System.Threading.Tasks;
using Antix.Data.Keywords.EF;
using Antix.Data.Keywords.Processing;
using Antix.EASI.Data.EF.Examinations.Models;
using Antix.EASI.Data.EF.People.Examiners.Models;
using Antix.EASI.Data.EF.People.Models;
using Antix.EASI.Data.EF.People.Patients.Models;

namespace Antix.EASI.Data.EF
{
    public class DataContext : DbContext
    {
        public const int PERSON_IDENTIFIER_LENGTH = 30;
        public const int NAME_LENGTH = 50;
        public const int NOTES_LENGTH = 500;

        readonly EFKeywordsManager _keywordsManager;

        // Required by migrations
        public DataContext()
            : this(new EFKeywordsManager(
                new KeywordsBuilderProvider(WordSplitKeywordProcessor.Create())))
        {
        }

        public DataContext(EFKeywordsManager keywordsManager)
        {
            _keywordsManager = keywordsManager;

            InitializeKeywordIndexing();
        }

        public IDbSet<PatientData> Patients { get; set; }
        public IDbSet<ExaminerData> Examiners { get; set; }

        public IDbSet<ExaminationData> Examinations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations
                .AddFromAssembly(typeof (PersonData).Assembly);
        }

        void InitializeKeywordIndexing()
        {
            _keywordsManager
                .Entity<ExaminerData>()
                .Index(entry => entry.Identifier)
                .Index(entry => entry.Person.Name);
            _keywordsManager
                .Entity<PatientData>()
                .Index(entry => entry.Identifier)
                .Index(entry => entry.Person.Name);
        }

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