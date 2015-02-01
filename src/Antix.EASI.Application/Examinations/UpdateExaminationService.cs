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
        ValidatingServiceBase<UpdateExaminationModel>, IUpdateExaminationService
    {
        public UpdateExaminationService(
            IValidator<UpdateExaminationModel> validator) :
                base(validator)
        {
        }

        protected override async Task<IServiceResponse> ThenAsync(
            UpdateExaminationModel model)
        {
            if (model == null) throw new ArgumentNullException("model");


            return ServiceResponse.Empty;
        }
    }
}