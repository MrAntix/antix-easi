using System;
using System.Threading.Tasks;
using Antix.EASI.Domain.People.Clincians;
using Antix.EASI.Domain.People.Clincians.Models;
using Antix.Services.Models;
using Antix.Services.Validation;
using Antix.Services.Validation.Services;

namespace Antix.EASI.Application.People.Patients
{
    public class UpdatePatientService :
        ValidatingServiceBase<UpdatePatientModel>, IUpdatePatientService
    {
        readonly IUpdatePatientDataService _dataService;

        public UpdatePatientService(
            IValidator<UpdatePatientModel> validator, 
            IUpdatePatientDataService dataService) : 
                base(validator)
        {
            _dataService = dataService;
        }

        protected override async Task<IServiceResponse> ThenAsync(
            UpdatePatientModel model)
        {
            if (model == null) throw new ArgumentNullException("model");

            await _dataService.ExecuteAsync(model);

            return ServiceResponse.Empty;
        }
    }
}