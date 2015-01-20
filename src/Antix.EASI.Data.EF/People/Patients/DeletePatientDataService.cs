using System;
using System.Threading.Tasks;
using Antix.EASI.Application.People.Patients;

namespace Antix.EASI.Data.EF.People.Patients
{
    public class DeletePatientDataService :
        IDeletePatientDataService
    {
        readonly DataContext _dataContext;

        public DeletePatientDataService(
            DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task ExecuteAsync(Guid id)
        {
            if (id == null) throw new ArgumentNullException("id");

            var data = _dataContext.Patients.Find(id);

            _dataContext.Patients.Remove(data);
            await _dataContext.SaveChangesAsync();
        }
    }
}