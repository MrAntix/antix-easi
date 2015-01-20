using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Antix.EASI.Application.People.Examiners;
using Antix.EASI.Data.EF.People.Examiners.Models;
using Antix.EASI.Domain.People.Clincians.Models;

namespace Antix.EASI.Data.EF.People.Examiners
{
    public class UpdateExaminerDataService :
        IUpdateExaminerDataService
    {
        readonly DataContext _dataContext;

        public UpdateExaminerDataService(
            DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task ExecuteAsync(
            UpdateExaminerModel id)
        {
            var query = _dataContext.Examiners
                .Where(d => d.Id == id.Id);

            var data = await query.SingleAsync();

            data.Map(id);

            await _dataContext.SaveChangesAsync();
        }
    }
}