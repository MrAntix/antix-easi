using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Antix.Data.Keywords.EF;
using Antix.Data.Keywords.Processing;
using Antix.Data.Projections;
using Antix.EASI.Data.EF.Examinations.Models;
using Antix.EASI.Data.EF.People.Examiners.Models;
using Antix.EASI.Domain.Examinations;
using Antix.EASI.Domain.Examinations.Models;
using Antix.EASI.Domain.People.Examiners.Models;
using Antix.Services.Models;
using LinqKit;

namespace Antix.EASI.Data.EF.Examinations
{
    public class LookupExaminationsService :
        ILookupExaminationsService
    {
        readonly DataContext _dataContext;
        readonly IProjectionProvider _projectionProvider;
        readonly IKeywordProcessor _keywordProcessor;

        public LookupExaminationsService(
            DataContext dataContext,
            IProjectionProvider projectionProvider,
            IKeywordProcessor keywordProcessor)
        {
            _dataContext = dataContext;
            _projectionProvider = projectionProvider;
            _keywordProcessor = keywordProcessor;
        }

        public async Task<IServiceResponse<ExaminationInfoModel[]>> ExecuteAsync(
            LookupExaminationsModel model)
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

            var projected = query
                .Select(d => projectInfo.Invoke(d));

            projected = projected.OrderByDescending(d => d.TakenOn)
                .Skip(model.Index).Take(model.Count);

            var result = await projected
                .ToArrayAsync();

            return ServiceResponse.Empty
                .WithData(result);
        }
    }
}