using Antix.EASI.Domain.Examinations.Models;
using Antix.Services;

namespace Antix.EASI.Application.Examinations
{
    public interface IUpdateExaminationDataService :
        IServiceIn<ExaminationModel>
    {
    }
}