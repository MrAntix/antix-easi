using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Antix.EASI.Application.People.Patients;
using Antix.EASI.Data.EF.People.Patients.Models;
using Antix.EASI.Domain.People.Clincians.Models;

namespace Antix.EASI.Data.EF.People.Patients
{
    public class UpdatePatientDataService :
        IUpdatePatientDataService
    {
        readonly DataContext _dataContext;

        public UpdatePatientDataService(
            DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task ExecuteAsync(
            UpdatePatientModel id)
        {
            var query = _dataContext.Patients
                .Where(d => d.Id == id.Id);

            var data = await query.SingleAsync();

            data.Map(id);

            await _dataContext.SaveChangesAsync();
        }
    }
}