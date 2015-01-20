using System;
using System.Threading.Tasks;
using Antix.EASI.Application.People.Examiners;
using Antix.EASI.Data.EF.People.Examiners.Models;
using Antix.EASI.Domain.People.Clincians.Models;

namespace Antix.EASI.Data.EF.People.Examiners
{
    public class CreateExaminerDataService :
        ICreateExaminerDataService
    {
        readonly DataContext _dataContext;

        public CreateExaminerDataService(
            DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Guid> ExecuteAsync(CreateExaminerModel model)
        {
            if (model == null) throw new ArgumentNullException("model");

            var data = model.ToData();

            _dataContext.Examiners.Add(data);
            await _dataContext.SaveChangesAsync();

            return data.Id;
        }
    }
}