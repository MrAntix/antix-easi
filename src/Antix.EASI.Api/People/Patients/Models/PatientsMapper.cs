using System.Collections.Generic;
using System.Linq;
using Antix.EASI.Api.People.Models;
using Antix.EASI.Domain.People.Clincians.Models;

namespace Antix.EASI.Api.People.Patients.Models
{
    public static class PatientsMapper
    {
        public static PatientInfo ToContract(
            this PatientInfoModel model)
        {
            if (model == null) return null;

            return new PatientInfo
            {
                Id = model.Id,
                Name = model.Name,
                Identifier = model.Identifier
            };
        }

        public static PatientInfo[] ToContract(
            this IEnumerable<PatientInfoModel> models)
        {
            if (models == null) return null;

            return models.Select(m => m.ToContract()).ToArray();
        }

        public static Patient ToContract(
            this PatientModel model)
        {
            if (model == null) return null;

            return new Patient
            {
                Id = model.Id,
                Identifier = model.Identifier,
                Person = model.Person.ToContract()
            };
        }

        public static LookupPatientsModel ToModel(
            this LookupPatients contract)
        {
            if (contract == null) return null;

            return new LookupPatientsModel
            {
                Text = contract.Text,
                Index = contract.Index,
                Count = contract.Count
            };
        }

        public static CreatePatientModel ToModel(
            this CreatePatient contract)
        {
            if (contract == null) return null;

            return new CreatePatientModel
            {
                Identifier = contract.Identifier,
                Name = contract.Name
            };
        }

        public static UpdatePatientModel ToModel(
            this UpdatePatient contract)
        {
            if (contract == null) return null;

            return new UpdatePatientModel
            {
                Id = contract.Id,
                Identifier = contract.Identifier,
                Person = contract.Person.ToModel()
            };
        }
    }
}