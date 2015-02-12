using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Antix.Data.Keywords.Processing;
using Antix.Data.Projections;
using Antix.EASI.Data.EF.Examinations.Models;
using Antix.EASI.Domain.Examinations;
using Antix.EASI.Domain.Examinations.Models;
using Antix.Services.Models;
using LinqKit;

namespace Antix.EASI.Data.EF.Examinations
{
    public class SearchExaminationsService :
        ISearchExaminationsService
    {
        readonly DataContext _dataContext;
        readonly IProjectionProvider _projectionProvider;
        readonly IKeywordProcessor _keywordProcessor;

        public SearchExaminationsService(
            DataContext dataContext,
            IProjectionProvider projectionProvider,
            IKeywordProcessor keywordProcessor)
        {
            _dataContext = dataContext;
            _projectionProvider = projectionProvider;
            _keywordProcessor = keywordProcessor;
        }

        public async Task<IServiceResponse<SearchExaminationsResultModel>> ExecuteAsync(
            SearchExaminationsModel model)
        {
            if (model == null) throw new ArgumentNullException("model");

            var projectInfo =
                _projectionProvider.Get<ExaminationData, ExaminationInfoModel>();

            var query = _dataContext
                .Examinations.AsExpandable();

            if (!string.IsNullOrWhiteSpace(model.Text))
            {
                //TODO
                //query = query
                //    .Match(model.Text, _keywordProcessor);
            }

            if (model.DateFrom.HasValue)
            {
                query = query
                    .Where(d => d.TakenOn >= model.DateFrom);
            }

            if (model.DateTo.HasValue)
            {
                query = query
                    .Where(d => d.TakenOn < model.DateTo);
            }

            var result = new SearchExaminationsResultModel
            {
                TotalCount = await query.CountAsync()
            };

            var projected = query
                .Select(d => projectInfo.Invoke(d));

            projected = projected.OrderBy(d => d.TakenOn)
                .Skip(model.Index).Take(model.Count);

            result.Items = await projected.ToArrayAsync();

            return ServiceResponse.Empty
                .WithData(result);
        }
    }
}