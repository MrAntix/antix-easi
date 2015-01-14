using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Antix.Data.Projections;
using Antix.EASI.Application.People.Clinicians;
using Antix.EASI.Data.EF.People.Clinicians.Models;
using Antix.EASI.Domain.People.Clincians.Models;
using LinqKit;

namespace Antix.EASI.Data.EF.People.Clinicians
{
    public class ReadClinicianDataService :
        IReadClinicianDataService
    {
        readonly DataContext _dataContext;
        readonly IProjectionProvider _projectionProvider;

        public ReadClinicianDataService(
            DataContext dataContext, IProjectionProvider projectionProvider)
        {
            _dataContext = dataContext;
            _projectionProvider = projectionProvider;
        }

        public Task<ClinicianModel> ExecuteAsync(Guid id)
        {
            var query = _dataContext.Clinicians.AsExpandable()
                .Where(d => d.Id == id);

            var project = _projectionProvider.Get<ClinicianData, ClinicianModel>();

            var result = query
                .Select(d => project.Invoke(d))
                .SingleOrDefaultAsync();

            return result;
        }
    }
}