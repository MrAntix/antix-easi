using System.Threading.Tasks;
using System.Web.Http;
using Antix.EASI.Api.People.Clinicians.Models;
using Antix.EASI.Domain.People.Clincians;
using Antix.Services.Models;

namespace Antix.EASI.Api.People.Clinicians
{
    [RoutePrefix(ApiRoutes.ROOT)]
    public class CliniciansWriteController :
        ApiController
    {
        readonly IUpdateClinicianService _service;

        public CliniciansWriteController(
            IUpdateClinicianService readService)
        {
            _service = readService;
        }

        [Route(ApiRoutes.Clinicians.UPDATE)]
        public async Task<IServiceResponse> Get(
            UpdateClinician contract)
        {
            var response = await _service.ExecuteAsync(
                contract.ToModel()
                );

            return response;
        }
    }
}