using System;
using System.Threading.Tasks;
using Antix.EASI.Application.People.Clinicians;

namespace Antix.EASI.Data.EF.People.Clinicians
{
    public class DeleteClinicianDataService :
        IDeleteClinicianDataService
    {
        readonly DataContext _dataContext;

        public DeleteClinicianDataService(
            DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task ExecuteAsync(Guid id)
        {
            if (id == null) throw new ArgumentNullException("id");

            var data = _dataContext.Clinicians.Find(id);

            _dataContext.Clinicians.Remove(data);
            await _dataContext.SaveChangesAsync();
        }
    }
}