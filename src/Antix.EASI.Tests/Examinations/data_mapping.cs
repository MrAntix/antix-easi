using Antix.EASI.Data.EF.Examinations.Models;
using Antix.EASI.Domain.Examinations.Models;
using Xunit;

namespace Antix.EASI.Tests.Examinations
{
    public class data_mapping
    {
        [Fact]
        public void adds_new_data_model_to_property_when_null()
        {
            var examinationData = new ExaminationData();
            var scoresModel = new ExaminationRegionScoresModel();

            examinationData.TryAddOrUpdate(d => d.HeadNeck, scoresModel);

            Assert.NotNull(examinationData.HeadNeck);
        }
    }
}