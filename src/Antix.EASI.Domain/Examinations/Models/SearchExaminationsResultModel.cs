namespace Antix.EASI.Domain.Examinations.Models
{
    public class SearchExaminationsResultModel
    {
        public ExaminationInfoModel[] Items { get; set; }
        public int TotalCount { get; set; }
    }
}