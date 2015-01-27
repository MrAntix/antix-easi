using System;
using Antix.Services;
using Antix.Services.Validation.Predicates;

namespace Antix.EASI.Domain.People.Examiners.Validation.Predicates
{
    public interface IExaminerExistsPredicate :
        IValidationPredicate<Guid>, IService
    {
    }
}