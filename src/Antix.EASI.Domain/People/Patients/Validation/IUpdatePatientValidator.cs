using Antix.EASI.Domain.People.Patients.Models;
using Antix.Services.Validation;

namespace Antix.EASI.Domain.People.Patients.Validation
{
    public interface IUpdatePatientValidator :
        IValidator<UpdatePatientModel>
    {
    }
}