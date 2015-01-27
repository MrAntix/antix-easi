using System.Threading.Tasks;
using System.Web.Http;
using Antix.EASI.Api.Examinations.Models;
using Antix.EASI.Domain.Examinations;
using Antix.Http;
using Antix.Services.Models;

namespace Antix.EASI.Api.Examinations
{
    [RoutePrefix(ApiRoutes.ROOT)]
    public class ExaminationsListController :
        ApiController
    {
        readonly ICreateExaminationService _createService;

        public ExaminationsListController(
            ICreateExaminationService createService)
        {
            _createService = createService;
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