using System;
using System.Linq;
using Antix.EASI.Domain.People.Patients.Validation.Predicates;

namespace Antix.EASI.Data.EF.People.Patients.Validation.Predicates
{
    public class PatientExistsPredicate :
        IPatientExistsPredicate
    {
        readonly DataContext _dataContext;

        public PatientExistsPredicate(
            DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool Is(Guid model)
        {
            return _dataContext
                .Patients
                .Any(d => d.Id == model);
        }

        public override string ToString()
        {
            return "exists";
        }
    }
}