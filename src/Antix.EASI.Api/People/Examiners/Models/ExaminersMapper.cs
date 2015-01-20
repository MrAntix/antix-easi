using System.Collections.Generic;
using System.Linq;
using Antix.EASI.Api.People.Models;
using Antix.EASI.Domain.People.Clincians.Models;

namespace Antix.EASI.Api.People.Examiners.Models
{
    public static class ExaminersMapper
    {
        public static ExaminerInfo ToContract(
            this ExaminerInfoModel model)
        {
            if (model == null) return null;

            return new ExaminerInfo
            {
                Id = model.Id,
                Name = model.Name,
                Identifier = model.Identifier
            };
        }

        public static ExaminerInfo[] ToContract(
            this IEnumerable<ExaminerInfoModel> models)
        {
            if (models == null) return null;

            return models.Select(m => m.ToContract()).ToArray();
        }

        public static Examiner ToContract(
            this ExaminerModel model)
        {
            if (model == null) return null;

            return new Examiner
            {
                Id = model.Id,
                Identifier = model.Identifier,
                Person = model.Person.ToContract()
            };
        }

        public static LookupExaminersModel ToModel(
            this LookupExaminers contract)
        {
            if (contract == null) return null;

            return new LookupExaminersModel
            {
                Text = contract.Text,
                Index = contract.Index,
                Count = contract.Count
            };
        }

        public static CreateExaminerModel ToModel(
            this CreateExaminer contract)
        {
            if (contract == null) return null;

            return new CreateExaminerModel
            {
                Identifier = contract.Identifier,
                Name = contract.Name
            };
        }

        public static UpdateExaminerModel ToModel(
            this UpdateExaminer contract)
        {
            if (contract == null) return null;

            return new UpdateExaminerModel
            {
                Id = contract.Id,
                Identifier = contract.Identifier,
                Person = contract.Person.ToModel()
            };
        }
    }
}