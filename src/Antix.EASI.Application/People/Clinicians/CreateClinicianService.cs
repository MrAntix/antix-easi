using System;
using System.Threading.Tasks;
using Antix.EASI.Domain.People.Clincians;
using Antix.EASI.Domain.People.Clincians.Models;
using Antix.Services.Models;
using Antix.Services.Validation;
using Antix.Services.Validation.Services;

namespace Antix.EASI.Application.People.Clinicians
{
    public class CreateClinicianService :
        ValidatingServiceBase<CreateClinicianModel, Guid>, ICreateClinicianService
    {
        readonly IAddClinicianDataService _dataService;

        public CreateClinicianService(
            IValidator<CreateClinicianModel> validator,
            IAddClinicianDataService dataService) :
                base(validator)
        {
            _dataService = dataService;
        }

        protected override async Task<IServiceResponse<Guid>> ThenAsync(
            CreateClinicianModel model)
        {
            var result = await _dataService.ExecuteAsync(model);

            return ServiceResponse.Empty.WithData(result);
        }
    }
}