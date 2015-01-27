using System;
using Antix.Services;
using Antix.Services.Models;

namespace Antix.EASI.Domain.People.Patients
{
    public interface IDeletePatientService :
        IServiceInOut<Guid, IServiceResponse>
    {
    }
}