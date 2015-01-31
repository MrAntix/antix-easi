using System;
using System.Threading.Tasks;
using Antix.EASI.Domain.People.Examiners;
using Antix.EASI.Domain.People.Examiners.Models;
using Antix.Services.Models;
using Antix.Services.Validation;
using Antix.Services.Validation.Services;

namespace Antix.EASI.Application.People.Examiners
{
    public class CreateExaminerService :
        ValidatingServiceBase<CreateExaminerModel, ExaminerInfoModel>, 
        ICreateExaminerService
    {
        readonly ICreateExaminerDataService _dataService;

        public CreateExaminerService(
            IValidator<CreateExaminerModel> validator,
            ICreateExaminerDataService dataService) :
                base(validator)
        {
            _dataService = dataService;
        }

        protected override async Task<IServiceResponse<ExaminerInfoModel>> ThenAsync(
            CreateExaminerModel model)
        {
            if (model == null) throw new ArgumentNullException("model");

            var result = await _dataService.ExecuteAsync(model);

            return ServiceResponse.Empty.WithData(result);
        }
    }
}