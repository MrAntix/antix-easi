using System;
using Antix.Services;
using Antix.Services.Models;

namespace Antix.EASI.Domain.People.Examiners
{
    public interface IDeleteExaminerService :
        IServiceInOut<Guid, IServiceResponse>
    {
    }
}