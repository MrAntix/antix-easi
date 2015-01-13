﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Antix.EASI.Api.Clinicians.Models;
using Antix.EASI.Domain.People.Clincians;
using Antix.EASI.Domain.People.Clincians.Models;
using Antix.Services.Models;

namespace Antix.EASI.Api.Clinicians
{
    [RoutePrefix(ApiRoutes.ROOT)]
    public class CliniciansLookupController :
        ApiController
    {
        readonly ILookupCliniciansService _lookupService;

        public CliniciansLookupController(
            ILookupCliniciansService lookupService)
        {
            _lookupService = lookupService;
        }

        [Route(ApiRoutes.Clinicians.LOOKUP)]
        public async Task<IServiceResponse<IEnumerable<ClinicianInfo>>> Get()
        {
            var data = await _lookupService.ExecuteAsync();

            return data.Map(m => m.ToContract());
        }
    }
}