using System.Collections.Generic;
using System.Linq;
using Antix.EASI.Api.People.Models;
using Antix.EASI.Domain.People.Clincians.Models;

namespace Antix.EASI.Api.People.Clinicians.Models
{
    public static class CliniciansMapper
    {
        public static ClinicianInfo ToContract(
            this ClinicianInfoModel model)
        {
            if (model == null) return null;

            return new ClinicianInfo
            {
                Id = model.Id,
                Name = model.Name,
                Identifier = model.Identifier
            };
        }

        public static ClinicianInfo[] ToContract(
            this IEnumerable<ClinicianInfoModel> models)
        {
            if (models == null) return null;

            return models.Select(m => m.ToContract()).ToArray();
        }

        public static Clinician ToContract(
            this ClinicianModel model)
        {
            if (model == null) return null;

            return new Clinician
            {
                Id = model.Id,
                Identifier = model.Identifier,
                Person = model.Person.ToContract()
            };
        }

        public static LookupCliniciansModel ToModel(
            this LookupClinicians contract)
        {
            if (contract == null) return null;

            return new LookupCliniciansModel
            {
                Text = contract.Text,
                Index = contract.Index,
                Count = contract.Count
            };
        }

        public static CreateClinicianModel ToModel(
            this CreateClinician contract)
        {
            if (contract == null) return null;

            return new CreateClinicianModel
            {
                Identifier = contract.Identifier,
                Name = contract.Name
            };
        }

        public static UpdateClinicianModel ToModel(
            this UpdateClinician contract)
        {
            if (contract == null) return null;

            return new UpdateClinicianModel
            {
                Id = contract.Id,
                Identifier = contract.Identifier,
                Person = contract.Person.ToModel()
            };
        }
    }
}