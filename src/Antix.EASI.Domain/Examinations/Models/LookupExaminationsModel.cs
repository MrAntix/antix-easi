using System;

namespace Antix.EASI.Domain.Examinations.Models
{
    public class LookupExaminationsModel
    {
        int _count;

        public string Text { get; set; }
        public DateTimeOffset? DateFrom { get; set; }
        public DateTimeOffset? DateTo { get; set; }

        public int Index { get; set; }

        public int Count
        {
            get { return _count < 5 ? 5 : _count > 20 ? 20 : _count; }
            set { _count = value; }
        }

        public static readonly LookupExaminationsModel Default
            = new LookupExaminationsModel
            {
                Text = null,
                Index = 0,
                Count = 10
            };
    }
}