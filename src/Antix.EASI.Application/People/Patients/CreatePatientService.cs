using System;
using System.Threading.Tasks;
using Antix.EASI.Domain.People.Patients;
using Antix.EASI.Domain.People.Patients.Models;
using Antix.Services.Models;
using Antix.Services.Validation;
using Antix.Services.Validation.Services;

namespace Antix.EASI.Application.People.Patients
{
    public class CreatePatientService :
        ValidatingServiceBase<CreatePatientModel, Guid>, ICreatePatientService
    {
        readonly ICreatePatientDataService _dataService;

        public CreatePatientService(
            IValidator<CreatePatientModel> validator,
            ICreatePatientDataService dataService) :
                base(validator)
        {
            _dataService = dataService;
        }

        protected override async Task<IServiceResponse<Guid>> ThenAsync(
            CreatePatientModel model)
        {
            if (model == null) throw new ArgumentNullException("model");

            var result = await _dataService.ExecuteAsync(model);

            return ServiceResponse.Empty.WithData(result);
        }
    }
}