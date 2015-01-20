using Antix.EASI.Domain.People.Clincians.Models;
using Antix.Services.Validation;

namespace Antix.EASI.Domain.People.Clincians.Validation
{
    public interface ICreatePatientValidator :
        IValidator<CreatePatientModel>
    {
    }
}