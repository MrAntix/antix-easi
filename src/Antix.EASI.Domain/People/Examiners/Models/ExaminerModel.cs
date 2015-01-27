using System;
using Antix.EASI.Domain.People.Models;

namespace Antix.EASI.Domain.People.Examiners.Models
{
    public class ExaminerModel
    {
        public ExaminerModel()
        {
            Person = new PersonModel();
        }

        public Guid Id { get; set; }
        public string Identifier { get; set; }
        public PersonModel Person { get; set; }
    }
}