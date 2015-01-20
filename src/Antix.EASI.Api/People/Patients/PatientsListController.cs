using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Antix.EASI.Api.People.Patients.Models;
using Antix.EASI.Domain.People.Clincians;
using Antix.EASI.Domain.People.Clincians.Models;
using Antix.Http;
using Antix.Services.Models;

namespace Antix.EASI.Api.People.Patients
{
    [RoutePrefix(ApiRoutes.ROOT)]
    public class PatientsListController :
        ApiController
    {
        readonly ILookupPatientsService _lookupService;
        readonly ICreatePatientService _createService;

        public PatientsListController(
            ILookupPatientsService lookupService,
            ICreatePatientService createService)
        {
            _lookupService = lookupService;
            _createService = createService;
        }

        [Route(ApiRoutes.Patients.LIST)]
        public async Task<IServiceResponse<IEnumerable<PatientInfo>>> Get(
            [FromUri] LookupPatients contract)
        {
            var response = await _lookupService.ExecuteAsync(
                contract.ToModel() ?? LookupPatientsModel.Default
                );

            return response.Map(m => m.ToContract());
        }

        [Route(ApiRoutes.Patients.CREATE)]
        public async Task<IServiceResponse> Post(
            CreatePatient contract)
        {
            var response = await _createService.ExecuteAsync(
                contract.ToModel()
                );

            return response.Created(
                ApiRoutes.Patients.READ_NAME,
                new
                {
                    id = response.Data
                });
        }

    }
}