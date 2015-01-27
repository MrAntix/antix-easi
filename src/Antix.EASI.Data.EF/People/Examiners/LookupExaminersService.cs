using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Antix.Data.Keywords.EF;
using Antix.Data.Keywords.Processing;
using Antix.Data.Projections;
using Antix.EASI.Data.EF.People.Examiners.Models;
using Antix.EASI.Domain.People.Examiners;
using Antix.EASI.Domain.People.Examiners.Models;
using Antix.Services.Models;
using LinqKit;

namespace Antix.EASI.Data.EF.People.Examiners
{
    public class LookupExaminersService :
        ILookupExaminersService
    {
        readonly DataContext _dataContext;
        readonly IProjectionProvider _projectionProvider;
        readonly IKeywordProcessor _keywordProcessor;

        public LookupExaminersService(
            DataContext dataContext,
            IProjectionProvider projectionProvider,
            IKeywordProcessor keywordProcessor)
        {
            _dataContext = dataContext;
            _projectionProvider = projectionProvider;
            _keywordProcessor = keywordProcessor;
        }

        public async Task<IServiceResponse<ExaminerInfoModel[]>> ExecuteAsync(
            LookupExaminersModel model)
        {
            if (model == null) throw new ArgumentNullException("model");

            var projectInfo =
                _projectionProvider.Get<ExaminerData, ExaminerInfoModel>();

            var query = _dataContext
                .Examiners.AsExpandable();

            if (!string.IsNullOrWhiteSpace(model.Text))
            {
                query = query
                    .Match(model.Text, _keywordProcessor);
            }

            var projected = query
                .Select(d => projectInfo.Invoke(d));

            if (string.IsNullOrWhiteSpace(model.Text))
            {
                projected = projected.OrderBy(d => d.Name);
            }

            var result = await projected
                .Skip(model.Index).Take(model.Count)
                .ToArrayAsync();

            return ServiceResponse.Empty
                .WithData(result);
        }
    }
}