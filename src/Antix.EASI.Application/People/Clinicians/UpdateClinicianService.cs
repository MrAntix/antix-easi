using System;
using System.Threading.Tasks;
using Antix.EASI.Domain.People.Clincians;
using Antix.EASI.Domain.People.Clincians.Models;
using Antix.Services.Models;
using Antix.Services.Validation;
using Antix.Services.Validation.Services;

namespace Antix.EASI.Application.People.Clinicians
{
    public class UpdateClinicianService :
        ValidatingServiceBase<UpdateClinicianModel>, IUpdateClinicianService
    {
        readonly IUpdateClinicianDataService _dataService;

        public UpdateClinicianService(
            IValidator<UpdateClinicianModel> validator, 
            IUpdateClinicianDataService dataService) : 
                base(validator)
        {
            _dataService = dataService;
        }

        protected override async Task<IServiceResponse> ThenAsync(
            UpdateClinicianModel model)
        {
            if (model == null) throw new ArgumentNullException("model");

            await _dataService.ExecuteAsync(model);

            return ServiceResponse.Empty;
        }
    }
}