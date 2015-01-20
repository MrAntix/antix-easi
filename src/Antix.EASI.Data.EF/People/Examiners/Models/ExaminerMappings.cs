using System;
using Antix.EASI.Data.EF.People.Models;
using Antix.EASI.Domain.People.Clincians.Models;

namespace Antix.EASI.Data.EF.People.Examiners.Models
{
    public static class ExaminerMappings
    {
        public static ExaminerData ToData(
            this CreateExaminerModel model)
        {
            if (model == null) throw new ArgumentNullException("model");

            return new ExaminerData
            {
                Id = Guid.NewGuid(),
                Identifier = model.Identifier,
                Person = new PersonData
                {
                    Name = model.Name
                }
            };
        }

        public static void Map(
            this ExaminerData data, UpdateExaminerModel model)
        {
            data.Identifier = model.Identifier;
            data.Person.Map(model.Person);
        }
    }
}