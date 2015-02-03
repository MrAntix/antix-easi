using Antix.EASI.Domain.Examinations.Models;
using Antix.Services.Validation;

namespace Antix.EASI.Domain.Examinations.Validation
{
    public interface IUpdateExaminationValidator :
        IValidator<ExaminationModel>
    {
    }
}