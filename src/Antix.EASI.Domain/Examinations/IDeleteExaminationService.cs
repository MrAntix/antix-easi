using System;
using Antix.Services;
using Antix.Services.Models;

namespace Antix.EASI.Domain.Examinations
{
    public interface IDeleteExaminationService :
        IServiceInOut<Guid, IServiceResponse>
    {
    }
}