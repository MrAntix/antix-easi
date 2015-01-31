using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Antix.EASI.Api.Examinations.Models;
using Antix.EASI.Domain.Examinations;
using Antix.EASI.Domain.Examinations.Models;
using Antix.Http;
using Antix.Services.Models;

namespace Antix.EASI.Api.Examinations
{
    [RoutePrefix(ApiRoutes.ROOT)]
    public class ExaminationsListController :
        ApiController
    {
        readonly ILookupExaminationsService _lookupService;
        readonly ICreateExaminationService _createService;

        public ExaminationsListController(
            ILookupExaminationsService lookupService,
            ICreateExaminationService createService)
        {
            _lookupService = lookupService;
            _createService = createService;
        }

        [Route(ApiRoutes.Examinations.LIST)]
        public async Task<IServiceResponse<IEnumerable<ExaminationInfo>>> Get(
            [FromUri] LookupExaminations contract)
        {
            var response = await _lookupService.ExecuteAsync(
                contract.ToModel() ?? LookupExaminationsModel.Default
                );

            return response.Map(m => m.ToContract());
        }

        [Route(ApiRoutes.Examinations.CREATE)]
        public async Task<IServiceResponse> Post(
            CreateExamination contract)
        {
            var response = await _createService.ExecuteAsync(
                contract.ToModel()
                );

            return response.Created(
                ApiRoutes.Examinations.READ_NAME,
                new
                {
                    id = response.Data
                });
        }
    }
}