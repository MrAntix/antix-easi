using System;
using System.Threading.Tasks;
using System.Web.Http;
using Antix.EASI.Api.Clinicians.Models;
using Antix.EASI.Domain.People.Clincians;
using Antix.Services.Models;

namespace Antix.EASI.Api.Clinicians
{
    [RoutePrefix(ApiRoutes.ROOT)]
    public class CliniciansCreateController :
        ApiController
    {
        readonly ICreateClinicianService _createService;

        public CliniciansCreateController(ICreateClinicianService createService)
        {
            _createService = createService;
        }

        [Route(ApiRoutes.Clinicians.CREATE)]
        public async Task<IServiceResponse<Guid>> Post(
            CreateClinician contract)
        {
            var data = await _createService.ExecuteAsync(
                contract.ToModel()
                );

            return data;
        }
    }
}