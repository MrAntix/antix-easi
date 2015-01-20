using System;
using Antix.Services;

namespace Antix.EASI.Application.People.Patients
{
    public interface IDeletePatientDataService :
        IServiceIn<Guid>
    {
    }
}