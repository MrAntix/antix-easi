using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Antix.EASI.Application.Examinations;
using Antix.EASI.Data.EF.Examinations.Models;
using Antix.EASI.Domain.Examinations.Models;

namespace Antix.EASI.Data.EF.Examinations
{
    public class UpdateExaminationDataService :
        IUpdateExaminationDataService
    {
        readonly DataContext _dataContext;

        public UpdateExaminationDataService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task ExecuteAsync(ExaminationModel model)
        {
            if (model == null) throw new ArgumentNullException("model");

            var data = await _dataContext.Examinations
                .SingleAsync(d => d.Id == model.Id);

            data.TryUpdate(model);

            await _dataContext.SaveChangesAsync();
        }
    }
}