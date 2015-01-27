using System;

namespace Antix.EASI.Domain.Examinations.Models
{
    public class CreateExaminationModel
    {
        public Guid ExaminerId { get; set; }
        public Guid PatientId { get; set; }
        public DateTimeOffset TakenOn { get; set; }
    }
}