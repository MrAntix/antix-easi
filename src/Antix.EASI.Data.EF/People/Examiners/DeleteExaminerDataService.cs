using System;
using System.Threading.Tasks;
using Antix.EASI.Application.People.Examiners;

namespace Antix.EASI.Data.EF.People.Examiners
{
    public class DeleteExaminerDataService :
        IDeleteExaminerDataService
    {
        readonly DataContext _dataContext;

        public DeleteExaminerDataService(
            DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task ExecuteAsync(Guid id)
        {
            if (id == null) throw new ArgumentNullException("id");

            var data = _dataContext.Examiners.Find(id);

            _dataContext.Examiners.Remove(data);
            await _dataContext.SaveChangesAsync();
        }
    }
}