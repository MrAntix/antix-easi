using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Antix.EASI.Application.People.Clinicians;
using Antix.EASI.Data.EF.People.Clinicians.Models;
using Antix.EASI.Domain.People.Clincians.Models;

namespace Antix.EASI.Data.EF.People.Clinicians
{
    public class UpdateClinicianDataService :
        IUpdateClinicianDataService
    {
        readonly DataContext _dataContext;

        public UpdateClinicianDataService(
            DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task ExecuteAsync(
            UpdateClinicianModel id)
        {
            var query = _dataContext.Clinicians
                .Where(d => d.Id == id.Id);

            var data = await query.SingleAsync();

            data.Map(id);

            await _dataContext.SaveChangesAsync();
        }
    }
}