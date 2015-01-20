using System;
using Antix.EASI.Domain.People.Clincians.Models;
using Antix.Services;

namespace Antix.EASI.Application.People.Examiners
{
    public interface IReadExaminerDataService :
        IServiceInOut<Guid, ExaminerModel>
    {
        
    }
}