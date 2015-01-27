using System;

namespace Antix.EASI.Api.Examinations.Models
{
    public class CreateExamination
    {
        public Guid ExaminerId { get; set; }
        public Guid PatientId { get; set; }
        public DateTimeOffset TakenOn { get; set; }
    }
}