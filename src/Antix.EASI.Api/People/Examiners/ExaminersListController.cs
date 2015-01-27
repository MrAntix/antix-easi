using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Antix.EASI.Api.People.Examiners.Models;
using Antix.EASI.Domain.People.Examiners;
using Antix.EASI.Domain.People.Examiners.Models;
using Antix.Http;
using Antix.Services.Models;

namespace Antix.EASI.Api.People.Examiners
{
    [RoutePrefix(ApiRoutes.ROOT)]
    public class ExaminersListController :
        ApiController
    {
        readonly ILookupExaminersService _lookupService;
        readonly ICreateExaminerService _createService;

        public ExaminersListController(
            ILookupExaminersService lookupService,
            ICreateExaminerService createService)
        {
            _lookupService = lookupService;
            _createService = createService;
        }

        [Route(ApiRoutes.Examiners.LIST)]
        public async Task<IServiceResponse<IEnumerable<ExaminerInfo>>> Get(
            [FromUri] LookupExaminers contract)
        {
            var response = await _lookupService.ExecuteAsync(
                contract.ToModel() ?? LookupExaminersModel.Default
                );

            return response.Map(m => m.ToContract());
        }

        [Route(ApiRoutes.Examiners.CREATE)]
        public async Task<IServiceResponse> Post(
            CreateExaminer contract)
        {
            var response = await _createService.ExecuteAsync(
                contract.ToModel()
                );

            return response.Created(
                ApiRoutes.Examiners.READ_NAME,
                new
                {
                    id = response.Data
                });
        }
    }
}