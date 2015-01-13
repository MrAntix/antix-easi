using System.Collections.Generic;
using System.Linq;
using Antix.EASI.Domain.People.Clincians.Models;

namespace Antix.EASI.Api.Clinicians.Models
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
                Name = model.Name
            };
        }

        public static ClinicianInfo[] ToContract(
            this IEnumerable<ClinicianInfoModel> models)
        {
            if (models == null) return null;

            return models.Select(m => m.ToContract()).ToArray();
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
    }
}