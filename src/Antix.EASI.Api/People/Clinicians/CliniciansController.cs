using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Antix.EASI.Api.People.Clinicians.Models;
using Antix.EASI.Domain.People.Clincians;
using Antix.Http;
using Antix.Services.Models;

namespace Antix.EASI.Api.People.Clinicians
{
    [RoutePrefix(ApiRoutes.ROOT)]
    public class CliniciansController :
        ApiController
    {
        readonly ILookupCliniciansService _lookupService;
        readonly ICreateClinicianService _createService;
        readonly IReadClinicianService _readService;
        readonly IUpdateClinicianService _updateService;
        readonly IDeleteClinicianService _deleteService;

        public CliniciansController(
            ILookupCliniciansService lookupService,
            ICreateClinicianService createService,
            IReadClinicianService readService,
            IUpdateClinicianService updateService,
            IDeleteClinicianService deleteService)
        {
            _lookupService = lookupService;
            _createService = createService;
            _readService = readService;
            _updateService = updateService;
            _deleteService = deleteService;
        }

        [Route(ApiRoutes.Clinicians.LOOKUP)]
        public async Task<IServiceResponse<IEnumerable<ClinicianInfo>>> Get(
            LookupClinicians contract)
        {
            var response = await _lookupService.ExecuteAsync();

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

        [Route(ApiRoutes.Clinicians.READ, Name = ApiRoutes.Clinicians.READ_NAME)]
        public async Task<IServiceResponse<Clinician>> Get(
            Guid id)
        {
            var response = await _readService.ExecuteAsync(
                id
                );

            return response.Map(m => m.ToContract());
        }

        [Route(ApiRoutes.Clinicians.UPDATE)]
        public async Task<IServiceResponse> Put(
            UpdateClinician contract)
        {
            var response = await _updateService.ExecuteAsync(
                contract.ToModel()
                );

            return response;
        }

        [Route(ApiRoutes.Clinicians.DELETE)]
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