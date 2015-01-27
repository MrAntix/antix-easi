using System;
using Antix.EASI.Domain.People.Patients.Models;
using Antix.Services;
using Antix.Services.Models;

namespace Antix.EASI.Domain.People.Patients
{
    public interface ICreatePatientService :
        IServiceInOut<CreatePatientModel, IServiceResponse<Guid>>
    {
    }
}