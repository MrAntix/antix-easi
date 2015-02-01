using System;
using System.Threading.Tasks;
using Antix.EASI.Domain.People.Examiners;
using Antix.EASI.Domain.People.Examiners.Models;
using Antix.Services.Models;

namespace Antix.EASI.Application.People.Examiners
{
    public class ReadExaminerService :
        IReadExaminerService
    {
        readonly IReadExaminerDataService _dataService;

        public ReadExaminerService(IReadExaminerDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<IServiceResponse<ExaminerModel>> ExecuteAsync(Guid model)
        {
            var result = await _dataService.ExecuteAsync(model);

            return ServiceResponse.Empty.WithData(result);
        }
    }
}