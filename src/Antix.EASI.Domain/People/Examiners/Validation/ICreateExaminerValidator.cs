using Antix.EASI.Domain.People.Examiners.Models;
using Antix.Services.Validation;

namespace Antix.EASI.Domain.People.Examiners.Validation
{
    public interface ICreateExaminerValidator :
        IValidator<CreateExaminerModel>
    {
    }
}