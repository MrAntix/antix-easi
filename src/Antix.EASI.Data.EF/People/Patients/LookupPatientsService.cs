using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Antix.Data.Keywords.EF;
using Antix.Data.Keywords.Processing;
using Antix.Data.Projections;
using Antix.EASI.Data.EF.People.Patients.Models;
using Antix.EASI.Domain.People.Patients;
using Antix.EASI.Domain.People.Patients.Models;
using Antix.Services.Models;
using LinqKit;

namespace Antix.EASI.Data.EF.People.Patients
{
    public class LookupPatientsService :
        ILookupPatientsService
    {
        readonly DataContext _dataContext;
        readonly IProjectionProvider _projectionProvider;
        readonly IKeywordProcessor _keywordProcessor;

        public LookupPatientsService(
            DataContext dataContext,
            IProjectionProvider projectionProvider,
            IKeywordProcessor keywordProcessor)
        {
            _dataContext = dataContext;
            _projectionProvider = projectionProvider;
            _keywordProcessor = keywordProcessor;
        }

        public async Task<IServiceResponse<PatientInfoModel[]>> ExecuteAsync(
            LookupPatientsModel model)
        {
            if (model == null) throw new ArgumentNullException("model");

            var projectInfo =
                _projectionProvider.Get<PatientData, PatientInfoModel>();

            var query = _dataContext
                .Patients.AsExpandable();

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