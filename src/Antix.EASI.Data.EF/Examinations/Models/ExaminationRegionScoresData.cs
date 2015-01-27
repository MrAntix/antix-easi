using System.Data.Entity.ModelConfiguration;

namespace Antix.EASI.Data.EF.Examinations.Models
{
    public class ExaminationRegionScoresData
    {
        public int Erthema { get; set; }
        public int EdemaPapulation { get; set; }
        public int Excoriation { get; set; }
        public int Lichenification { get; set; }
        public int Region { get; set; }

        public class Configuration :
            ComplexTypeConfiguration<ExaminationRegionScoresData>
        {
        }
    }
}