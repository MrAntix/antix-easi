using System;
using Antix.EASI.Api.People.Models;

namespace Antix.EASI.Api.People.Examiners.Models
{
    public class UpdateExaminer
    {
        public Guid Id { get; set; }
        public string Identifier { get; set; }
        public Person Person { get; set; }
    }
}