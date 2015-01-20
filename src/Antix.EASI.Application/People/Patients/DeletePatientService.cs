using System;
using System.Threading.Tasks;
using Antix.EASI.Domain.People.Clincians;
using Antix.Services.Models;

namespace Antix.EASI.Application.People.Patients
{
    public class DeletePatientService :
        IDeletePatientService
    {
        readonly IDeletePatientDataService _dataService;

        public DeletePatientService(
            IDeletePatientDataService dataService)
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