using System;
using System.Threading.Tasks;
using System.Web.Http;
using Antix.EASI.Api.People.Patients.Models;
using Antix.EASI.Domain.People.Clincians;
using Antix.Services.Models;

namespace Antix.EASI.Api.People.Patients
{
    [RoutePrefix(ApiRoutes.ROOT)]
    public class PatientsController :
        ApiController
    {
        readonly IReadPatientService _readService;
        readonly IUpdatePatientService _updateService;
        readonly IDeletePatientService _deleteService;

        public PatientsController(
            IReadPatientService readService,
            IUpdatePatientService updateService,
            IDeletePatientService deleteService)
        {
            _readService = readService;
            _updateService = updateService;
            _deleteService = deleteService;
        }

        [Route(ApiRoutes.Patients.READ, Name = ApiRoutes.Patients.READ_NAME)]
        public async Task<IServiceResponse<Patient>> Get(
            Guid id)
        {
            var response = await _readService.ExecuteAsync(
                id
                );

            return response.Map(m => m.ToContract());
        }

        [Route(ApiRoutes.Patients.UPDATE)]
        public async Task<IServiceResponse> Put(
            UpdatePatient contract)
        {
            var response = await _updateService.ExecuteAsync(
                contract.ToModel()
                );

            return response;
        }

        [Route(ApiRoutes.Patients.DELETE)]
        public async Task<IServiceResponse> Delete(
            Guid id)
        {
            var response = await _deleteService.ExecuteAsync(
                id
                );

            return response;
        }
    }
}