using System;
using System.Threading.Tasks;
using Antix.EASI.Domain.People.Clincians;
using Antix.EASI.Domain.People.Clincians.Models;
using Antix.Services.Models;
using Antix.Services.Validation;
using Antix.Services.Validation.Services;

namespace Antix.EASI.Application.People.Examiners
{
    public class UpdateExaminerService :
        ValidatingServiceBase<UpdateExaminerModel>, IUpdateExaminerService
    {
        readonly IUpdateExaminerDataService _dataService;

        public UpdateExaminerService(
            IValidator<UpdateExaminerModel> validator, 
            IUpdateExaminerDataService dataService) : 
                base(validator)
        {
            _dataService = dataService;
        }

        protected override async Task<IServiceResponse> ThenAsync(
            UpdateExaminerModel model)
        {
            if (model == null) throw new ArgumentNullException("model");

            await _dataService.ExecuteAsync(model);

            return ServiceResponse.Empty;
        }
    }
}