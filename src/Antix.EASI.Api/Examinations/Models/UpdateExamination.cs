using System;

namespace Antix.EASI.Api.Examinations.Models
{
    public class UpdateExamination
    {
        public Guid Id { get; set; }

        public DateTimeOffset TakenOn { get; set; }
    }
}