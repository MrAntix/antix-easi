using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Antix.EASI.Api.People.Clinicians.Models;
using Antix.EASI.Domain.People.Clincians;
using Antix.EASI.Domain.People.Clincians.Models;
using Antix.Http;
using Antix.Services.Models;

namespace Antix.EASI.Api.People.Clinicians
{
    [RoutePrefix(ApiRoutes.ROOT)]
    public class CliniciansListController :
        ApiController
    {
        readonly ILookupCliniciansService _lookupService;
        readonly ICreateClinicianService _createService;

        public CliniciansListController(
            ILookupCliniciansService lookupService,
            ICreateClinicianService createService)
        {
            _lookupService = lookupService;
            _createService = createService;
        }

        [Route(ApiRoutes.Clinicians.LIST)]
        public async Task<IServiceResponse<IEnumerable<ClinicianInfo>>> Get(
            [FromUri] LookupClinicians contract)
        {
            var response = await _lookupService.ExecuteAsync(
                contract.ToModel() ?? LookupCliniciansModel.Default
                );

            return response.Map(m => m.ToContract());
        }

        [Route(ApiRoutes.Clinicians.CREATE)]
        public async Task<IServiceResponse> Post(
            CreateClinician contract)
        {
            var response = await _createService.ExecuteAsync(
                contract.ToModel()
                );

            return response.Created(
                ApiRoutes.Clinicians.READ_NAME,
                new
                {
                    id = response.Data
                });
        }

    }
}