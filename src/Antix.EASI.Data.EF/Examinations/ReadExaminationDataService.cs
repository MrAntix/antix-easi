using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antix.Data.Projections;
using Antix.EASI.Application.Examinations;
using Antix.EASI.Data.EF.Examinations.Models;
using Antix.EASI.Domain.Examinations.Models;
using LinqKit;

namespace Antix.EASI.Data.EF.Examinations
{
    public class ReadExaminationDataService:
        IReadExaminationDataService
    {
        readonly DataContext _dataContext;
        readonly IProjectionProvider _projectionProvider;

        public ReadExaminationDataService(
            DataContext dataContext, 
            IProjectionProvider projectionProvider)
        {
            _dataContext = dataContext;
            _projectionProvider = projectionProvider;
        }


        public Task<ExaminationModel> ExecuteAsync(Guid id)
        {
            var query = _dataContext.Examinations.AsExpandable()
                 .Where(d => d.Id == id);

            var project = _projectionProvider.Get<ExaminationData, ExaminationModel>();

            var result = query
                .Select(d => project.Invoke(d))
                .SingleOrDefaultAsync();

            return result;
        }
    }
}
