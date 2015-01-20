using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Antix.Data.Projections;
using Antix.EASI.Application.People.Patients;
using Antix.EASI.Data.EF.People.Patients.Models;
using Antix.EASI.Domain.People.Clincians.Models;
using LinqKit;

namespace Antix.EASI.Data.EF.People.Patients
{
    public class ReadPatientDataService :
        IReadPatientDataService
    {
        readonly DataContext _dataContext;
        readonly IProjectionProvider _projectionProvider;

        public ReadPatientDataService(
            DataContext dataContext, IProjectionProvider projectionProvider)
        {
            _dataContext = dataContext;
            _projectionProvider = projectionProvider;
        }

        public Task<PatientModel> ExecuteAsync(Guid id)
        {
            var query = _dataContext.Patients.AsExpandable()
                .Where(d => d.Id == id);

            var project = _projectionProvider.Get<PatientData, PatientModel>();

            var result = query
                .Select(d => project.Invoke(d))
                .SingleOrDefaultAsync();

            return result;
        }
    }
}