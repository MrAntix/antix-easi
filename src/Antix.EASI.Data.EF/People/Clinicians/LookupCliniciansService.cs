using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Antix.Data.Keywords.EF;
using Antix.Data.Keywords.Processing;
using Antix.Data.Projections;
using Antix.EASI.Data.EF.People.Clinicians.Models;
using Antix.EASI.Domain.People.Clincians;
using Antix.EASI.Domain.People.Clincians.Models;
using Antix.Services.Models;
using LinqKit;

namespace Antix.EASI.Data.EF.People.Clinicians
{
    public class LookupCliniciansService :
        ILookupCliniciansService
    {
        readonly DataContext _dataContext;
        readonly IProjectionProvider _projectionProvider;
        readonly IKeywordProcessor _keywordProcessor;

        public LookupCliniciansService(
            DataContext dataContext,
            IProjectionProvider projectionProvider,
            IKeywordProcessor keywordProcessor)
        {
            _dataContext = dataContext;
            _projectionProvider = projectionProvider;
            _keywordProcessor = keywordProcessor;
        }

        public async Task<IServiceResponse<ClinicianInfoModel[]>> ExecuteAsync(
            LookupCliniciansModel model)
        {
            if (model == null) throw new ArgumentNullException("model");

            var projectInfo =
                _projectionProvider.Get<ClinicianData, ClinicianInfoModel>();

            var query = _dataContext
                .Clinicians.AsExpandable();

            if (!string.IsNullOrWhiteSpace(model.Text))
            {
                query = query
                    .Match(model.Text, _keywordProcessor);
            }

            var result = await query
                .Select(d => projectInfo.Invoke(d))
                .OrderBy(d => d.Name)
                .Skip(model.Index).Take(model.Count)
                .ToArrayAsync();

            return ServiceResponse.Empty
                .WithData(result);
        }
    }
}