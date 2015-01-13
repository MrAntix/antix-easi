using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Antix.Data.Projections;
using Antix.EASI.Data.EF.People.Clinicians.Models;
using Antix.EASI.Domain.People.Clincians;
using Antix.EASI.Domain.People.Clincians.Models;
using Antix.Services.Models;
using LinqKit;

namespace Antix.EASI.Data.EF.People.Clinicians
{
    public class LookupCliniciansService :
        ILookupCliniciansService
    {
        readonly DataContext _dataContext;
        readonly IProjectionProvider _projectionProvider;

        public LookupCliniciansService(
            DataContext dataContext, 
            IProjectionProvider projectionProvider)
        {
            _dataContext = dataContext;
            _projectionProvider = projectionProvider;
        }

        public async Task<IServiceResponse<ClinicianInfoModel[]>> ExecuteAsync()
        {
            var projectInfo =
                _projectionProvider.Get<ClinicianData, ClinicianInfoModel>();

            var result = await _dataContext
                .Clinicians.AsExpandable()
                .Select(d => projectInfo.Invoke(d))
                .ToArrayAsync();

            return ServiceResponse.Empty
                .WithData(result);
        }
    }
}