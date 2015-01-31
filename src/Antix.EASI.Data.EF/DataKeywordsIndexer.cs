using Antix.Data.Keywords.EF;
using Antix.Data.Keywords.Processing;
using Antix.EASI.Data.EF.People.Examiners.Models;
using Antix.EASI.Data.EF.People.Patients.Models;

namespace Antix.EASI.Data.EF
{
    public class DataKeywordsIndexer : DbKeywordsIndexer
    {
        public DataKeywordsIndexer(
            IKeywordsBuilderProvider builderProvider) :
                base(builderProvider)
        {
            InitializeKeywordIndexing();
        }

        void InitializeKeywordIndexing()
        {
            Entity<ExaminerData>()
                .Index(entry => entry.Identifier)
                .Index(entry => entry.Person.Name);

            Entity<PatientData>()
                .Index(entry => entry.Identifier)
                .Index(entry => entry.Person.Name);
        }
    }
}