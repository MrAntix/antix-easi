using System;
using System.Threading.Tasks;
using System.Web.Http;
using Antix.EASI.Api.People.Clinicians.Models;
using Antix.EASI.Domain.People.Clincians;
using Antix.Services.Models;

namespace Antix.EASI.Api.People.Clinicians
{
    [RoutePrefix(ApiRoutes.ROOT)]
    public class CliniciansReadController :
        ApiController
    {
        readonly IReadClinicianService _service;

        public CliniciansReadController(
            IReadClinicianService service)
        {
            _service = service;
        }

        [Route(ApiRoutes.Clinicians.READ)]
        public async Task<IServiceResponse<Clinician>> Get(
            Guid id)
        {
            var response = await _service.ExecuteAsync(
                id
                );

            return response.Map(m => m.ToContract());
        }
    }
}