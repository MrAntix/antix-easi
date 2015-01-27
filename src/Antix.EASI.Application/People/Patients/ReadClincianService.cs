using System;
using System.Threading.Tasks;
using Antix.EASI.Domain.People.Patients;
using Antix.EASI.Domain.People.Patients.Models;
using Antix.Services.Models;

namespace Antix.EASI.Application.People.Patients
{
    public class ReadClincianService :
        IReadPatientService
    {
        readonly IReadPatientDataService _dataService;

        public ReadClincianService(IReadPatientDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<IServiceResponse<PatientModel>> ExecuteAsync(Guid model)
        {
            var result = await _dataService.ExecuteAsync(model);

            return ServiceResponse.Empty.WithData(result);
        }
    }
}