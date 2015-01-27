using System;
using Antix.Services;
using Antix.Services.Validation.Predicates;

namespace Antix.EASI.Domain.People.Patients.Validation.Predicates
{
    public interface IPatientExistsPredicate :
        IValidationPredicate<Guid>, IService
    {
    }
}