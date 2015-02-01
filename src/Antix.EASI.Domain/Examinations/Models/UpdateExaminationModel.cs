using System;

namespace Antix.EASI.Domain.Examinations.Models
{
    public class UpdateExaminationModel
    {
        public Guid Id { get; set; }

        public DateTimeOffset TakenOn { get; set; }
    }
}