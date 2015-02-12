using System;

namespace Antix.EASI.Api.Examinations.Models
{
    public class SearchExaminations
    {
        public string Text { get; set; }
        public DateTimeOffset? DateFrom { get; set; }
        public DateTimeOffset? DateTo { get; set; }

        public int Index { get; set; }
        public int Count { get; set; }
    }
}