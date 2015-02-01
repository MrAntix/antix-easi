using System;
using System.Threading.Tasks;
using Antix.EASI.Domain.Examinations;
using Antix.Services.Models;

namespace Antix.EASI.Application.Examinations
{
    public class DeleteExaminationService :
        IDeleteExaminationService
    {
        readonly IDeleteExaminationDataService _dataService;

        public DeleteExaminationService(
            IDeleteExaminationDataService dataService)
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