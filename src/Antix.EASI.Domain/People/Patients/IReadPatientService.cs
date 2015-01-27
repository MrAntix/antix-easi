using System;
using Antix.EASI.Domain.People.Patients.Models;
using Antix.Services;
using Antix.Services.Models;

namespace Antix.EASI.Domain.People.Patients
{
    public interface IReadPatientService :
        IServiceInOut<Guid, IServiceResponse<PatientModel>>
    {
    }
}