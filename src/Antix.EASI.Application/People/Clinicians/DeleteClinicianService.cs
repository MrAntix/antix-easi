using System;
using System.Threading.Tasks;
using Antix.EASI.Domain.People.Clincians;
using Antix.Services.Models;

namespace Antix.EASI.Application.People.Clinicians
{
    public class DeleteClinicianService :
        IDeleteClinicianService
    {
        readonly IDeleteClinicianDataService _dataService;

        public DeleteClinicianService(
            IDeleteClinicianDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<IServiceResponse> ExecuteAsync(Guid model)
        {
            await _dataService.ExecuteAsync(model);

            return ServiceResponse.Empty;
        }
    }
}