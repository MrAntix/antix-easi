using System;
using System.Threading.Tasks;
using Antix.EASI.Application.Examinations;

namespace Antix.EASI.Data.EF.Examinations
{
    public class DeleteExaminationDataService :
        IDeleteExaminationDataService
    {
        readonly DataContext _dataContext;

        public DeleteExaminationDataService(
            DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task ExecuteAsync(Guid id)
        {
            if (id == null) throw new ArgumentNullException("id");

            var data = _dataContext.Examinations.Find(id);

            _dataContext.Examinations.Remove(data);
            await _dataContext.SaveChangesAsync();
        }
    }
}