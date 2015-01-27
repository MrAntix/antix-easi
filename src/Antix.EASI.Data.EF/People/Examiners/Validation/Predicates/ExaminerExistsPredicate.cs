using System;
using System.Linq;
using Antix.EASI.Domain.People.Examiners.Validation.Predicates;

namespace Antix.EASI.Data.EF.People.Examiners.Validation.Predicates
{
    public class ExaminerExistsPredicate :
        IExaminerExistsPredicate
    {
        readonly DataContext _dataContext;

        public ExaminerExistsPredicate(
            DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool Is(Guid model)
        {
            return _dataContext
                .Examiners
                .Any(d => d.Id == model);
        }
    }
}