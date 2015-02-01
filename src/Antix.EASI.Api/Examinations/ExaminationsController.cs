using System;
using System.Threading.Tasks;
using System.Web.Http;
using Antix.EASI.Api.Examinations.Models;
using Antix.EASI.Domain.Examinations;
using Antix.Services.Models;

namespace Antix.EASI.Api.Examinations
{
    [RoutePrefix(ApiRoutes.ROOT)]
    public class ExaminationsController :
        ApiController
    {
        readonly IReadExaminationService _readService;
        readonly IUpdateExaminationService _updateService;
        readonly IDeleteExaminationService _deleteService;

        public ExaminationsController(
            IReadExaminationService readService,
            IUpdateExaminationService updateService,
            IDeleteExaminationService deleteService)
        {
            _readService = readService;
            _updateService = updateService;
            _deleteService = deleteService;
        }

        [Route(ApiRoutes.Examinations.READ, Name = ApiRoutes.Examinations.READ_NAME)]
        public async Task<IServiceResponse<Examination>> Get(
            Guid id)
        {
            var response = await _readService.ExecuteAsync(
                id
                );

            return response.Map(m => m.ToContract());
        }

        [Route(ApiRoutes.Examinations.UPDATE)]
        public async Task<IServiceResponse> Put(
            UpdateExamination contract)
        {
            var response = await _updateService.ExecuteAsync(
                contract.ToModel()
                );

            return response;
        }

        [Route(ApiRoutes.Examinations.DELETE)]
        public async Task<IServiceResponse> Delete(
            Guid id)
        {
            var response = await _deleteService.ExecuteAsync(
                id
                );

            return response;
        }
    }
}