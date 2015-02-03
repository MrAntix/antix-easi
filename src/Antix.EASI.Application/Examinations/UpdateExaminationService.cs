using System;
using System.Threading.Tasks;
using Antix.EASI.Domain.Examinations;
using Antix.EASI.Domain.Examinations.Models;
using Antix.Services.Models;
using Antix.Services.Validation;
using Antix.Services.Validation.Services;

namespace Antix.EASI.Application.Examinations
{
    public class UpdateExaminationService :
        ValidatingServiceBase<ExaminationModel>, IUpdateExaminationService
    {
        readonly IUpdateExaminationDataService _updateService;

        public UpdateExaminationService(
            IUpdateExaminationDataService updateService,
            IValidator<ExaminationModel> validator) :
                base(validator)
        {
            _updateService = updateService;
        }

        protected override async Task<IServiceResponse> ThenAsync(
            ExaminationModel model)
        {
            if (model == null) throw new ArgumentNullException("model");

            await _updateService.ExecuteAsync(model);

            return ServiceResponse.Empty;
        }
    }
}