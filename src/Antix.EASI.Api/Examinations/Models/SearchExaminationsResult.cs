using System.Collections.Generic;

namespace Antix.EASI.Api.Examinations.Models
{
    public class SearchExaminationsResult
    {
        public IEnumerable<ExaminationInfo> Items { get; set; }
        public int TotalCount { get; set; }
    }
}