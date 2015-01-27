using System;
using System.Threading.Tasks;
using Antix.EASI.Domain.People.Examiners;
using Antix.Services.Models;

namespace Antix.EASI.Application.People.Examiners
{
    public class DeleteExaminerService :
        IDeleteExaminerService
    {
        readonly IDeleteExaminerDataService _dataService;

        public DeleteExaminerService(
            IDeleteExaminerDataService dataService)
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