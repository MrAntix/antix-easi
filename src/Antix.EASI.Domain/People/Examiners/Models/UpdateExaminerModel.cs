using System;
using Antix.EASI.Domain.People.Models;

namespace Antix.EASI.Domain.People.Examiners.Models
{
    public class UpdateExaminerModel
    {
        public UpdateExaminerModel()
        {
            Person = new UpdatePersonModel();
        }

        public Guid Id { get; set; }
        public string Identifier { get; set; }
        public UpdatePersonModel Person { get; set; }
    }
}