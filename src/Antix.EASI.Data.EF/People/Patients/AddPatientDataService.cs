using System;
using System.Threading.Tasks;
using Antix.EASI.Application.People.Patients;
using Antix.EASI.Domain.People.Patients.Models;

namespace Antix.EASI.Data.EF.People.Patients
{
    public class AddPatientDataService :
        IAddPatientDataService
    {
        readonly DataContext _dataContext;

        public AddPatientDataService(
            DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Guid> ExecuteAsync(CreatePatientModel model)
        {
            var data = model.ToData();

            _dataContext.Patients.Add(data);
            await _dataContext.SaveChangesAsync();

            return data.Id;
        }
    }
}