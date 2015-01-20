using System;
using Antix.EASI.Domain.People.Clincians.Models;
using Antix.Services;

namespace Antix.EASI.Application.People.Patients
{
    public interface ICreatePatientDataService :
        IServiceInOut<CreatePatientModel, Guid>
    {
    }
}