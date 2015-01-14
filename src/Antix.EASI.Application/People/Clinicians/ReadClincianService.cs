using System;
using System.Threading.Tasks;
using Antix.EASI.Domain.People.Clincians;
using Antix.EASI.Domain.People.Clincians.Models;
using Antix.Services.Models;

namespace Antix.EASI.Application.People.Clinicians
{
    public class ReadClincianService :
        IReadClinicianService
    {
        readonly IReadClinicianDataService _dataService;

        public ReadClincianService(IReadClinicianDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<IServiceResponse<ClinicianModel>> ExecuteAsync(Guid model)
        {
            var result = await _dataService.ExecuteAsync(model);

            return ServiceResponse.Empty.WithData(result);
        }
    }
}