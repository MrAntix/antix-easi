using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Antix.Data.Projections;
using Antix.EASI.Application.People.Examiners;
using Antix.EASI.Data.EF.People.Examiners.Models;
using Antix.EASI.Domain.People.Clincians.Models;
using LinqKit;

namespace Antix.EASI.Data.EF.People.Examiners
{
    public class ReadExaminerDataService :
        IReadExaminerDataService
    {
        readonly DataContext _dataContext;
        readonly IProjectionProvider _projectionProvider;

        public ReadExaminerDataService(
            DataContext dataContext, IProjectionProvider projectionProvider)
        {
            _dataContext = dataContext;
            _projectionProvider = projectionProvider;
        }

        public Task<ExaminerModel> ExecuteAsync(Guid id)
        {
            var query = _dataContext.Examiners.AsExpandable()
                .Where(d => d.Id == id);

            var project = _projectionProvider.Get<ExaminerData, ExaminerModel>();

            var result = query
                .Select(d => project.Invoke(d))
                .SingleOrDefaultAsync();

            return result;
        }
    }
}