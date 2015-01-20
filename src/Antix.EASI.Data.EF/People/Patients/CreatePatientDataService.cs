using System;
using System.Threading.Tasks;
using Antix.EASI.Application.People.Patients;
using Antix.EASI.Data.EF.People.Patients.Models;
using Antix.EASI.Domain.People.Clincians.Models;

namespace Antix.EASI.Data.EF.People.Patients
{
    public class CreatePatientDataService :
        ICreatePatientDataService
    {
        readonly DataContext _dataContext;

        public CreatePatientDataService(
            DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Guid> ExecuteAsync(CreatePatientModel model)
        {
            if (model == null) throw new ArgumentNullException("model");

            var data = model.ToData();

            _dataContext.Patients.Add(data);
            await _dataContext.SaveChangesAsync();

            return data.Id;
        }
    }
}