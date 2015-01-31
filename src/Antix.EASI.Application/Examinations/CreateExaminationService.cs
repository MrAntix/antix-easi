using System;
using System.Threading.Tasks;
using Antix.EASI.Domain.Examinations;
using Antix.EASI.Domain.Examinations.Models;
using Antix.Services.Models;
using Antix.Services.Validation;
using Antix.Services.Validation.Services;

namespace Antix.EASI.Application.Examinations
{
    public class CreateExaminationService :
        ValidatingServiceBase<CreateExaminationModel, Guid>, ICreateExaminationService
    {
        readonly ICreateExaminationDataService _dataService;

        public CreateExaminationService(
            IValidator<CreateExaminationModel> validator,
            ICreateExaminationDataService dataService) :
                base(validator)
        {
            _dataService = dataService;
        }

        protected override async Task<IServiceResponse<Guid>> ThenAsync(
            CreateExaminationModel model)
        {
            if (model == null) throw new ArgumentNullException("model");

            var result = await _dataService.ExecuteAsync(model);

            return ServiceResponse.Empty.WithData(result);
        }
    }
}