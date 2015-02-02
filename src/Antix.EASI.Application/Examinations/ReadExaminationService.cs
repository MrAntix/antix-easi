using System;
using System.Threading.Tasks;
using Antix.EASI.Domain.Examinations;
using Antix.EASI.Domain.Examinations.Models;
using Antix.Services.Models;

namespace Antix.EASI.Application.Examinations
{
    public class ReadExaminationService :
        IReadExaminationService
    {
        readonly IReadExaminationDataService _dataService;

        public ReadExaminationService(IReadExaminationDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<IServiceResponse<ExaminationModel>> ExecuteAsync(Guid model)
        {
            var result = await _dataService.ExecuteAsync(model);

            return ServiceResponse.Empty.WithData(result);
        }
    }
}