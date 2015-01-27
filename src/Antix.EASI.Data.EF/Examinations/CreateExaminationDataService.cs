using System;
using System.Threading.Tasks;
using Antix.EASI.Application.Examinations;
using Antix.EASI.Data.EF.Examinations.Models;
using Antix.EASI.Domain.Examinations.Models;

namespace Antix.EASI.Data.EF.Examinations
{
    public class CreateExaminationDataService :
        ICreateExaminationDataService
    {
        readonly DataContext _dataContext;

        public CreateExaminationDataService(
            DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Guid> ExecuteAsync(CreateExaminationModel model)
        {
            if (model == null) throw new ArgumentNullException("model");

            var data = model.ToData();

            _dataContext.Examinations.Add(data);
            await _dataContext.SaveChangesAsync();

            return data.Id;
        }
    }
}