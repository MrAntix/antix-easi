using System;
using Antix.EASI.Domain.People.Examiners.Models;
using Antix.Services;

namespace Antix.EASI.Application.People.Examiners
{
    public interface ICreateExaminerDataService :
        IServiceInOut<CreateExaminerModel, Guid>
    {
    }
}