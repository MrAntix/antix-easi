using Antix.EASI.Domain.People.Models;
using Antix.Services.Validation;

namespace Antix.EASI.Domain.People.Validation
{
    public interface IUpdatePersonValidator :
        IValidator<UpdatePersonModel>
    {
    }
}