using System;
using System.Threading.Tasks;
using Antix.EASI.Application.People.Clinicians;
using Antix.EASI.Domain.People.Clincians.Models;

namespace Antix.EASI.Data.EF.People.Clinicians
{
    public class AddClinicianDataService :
        IAddClinicianDataService
    {
        readonly DataContext _dataContext;

        public AddClinicianDataService(
            DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Guid> ExecuteAsync(CreateClinicianModel model)
        {
            var data = model.ToData();

            _dataContext.Clinicians.Add(data);
            await _dataContext.SaveChangesAsync();

            return data.Id;
        }
    }
}