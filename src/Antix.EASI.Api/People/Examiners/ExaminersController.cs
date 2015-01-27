using System;
using System.Threading.Tasks;
using System.Web.Http;
using Antix.EASI.Api.People.Examiners.Models;
using Antix.EASI.Domain.People.Examiners;
using Antix.Services.Models;

namespace Antix.EASI.Api.People.Examiners
{
    [RoutePrefix(ApiRoutes.ROOT)]
    public class ExaminersController :
        ApiController
    {
        readonly IReadExaminerService _readService;
        readonly IUpdateExaminerService _updateService;
        readonly IDeleteExaminerService _deleteService;

        public ExaminersController(
            IReadExaminerService readService,
            IUpdateExaminerService updateService,
            IDeleteExaminerService deleteService)
        {
            _readService = readService;
            _updateService = updateService;
            _deleteService = deleteService;
        }

        [Route(ApiRoutes.Examiners.READ, Name = ApiRoutes.Examiners.READ_NAME)]
        public async Task<IServiceResponse<Examiner>> Get(
            Guid id)
        {
            var response = await _readService.ExecuteAsync(
                id
                );

            return response.Map(m => m.ToContract());
        }

        [Route(ApiRoutes.Examiners.UPDATE)]
        public async Task<IServiceResponse> Put(
            UpdateExaminer contract)
        {
            var response = await _updateService.ExecuteAsync(
                contract.ToModel()
                );

            return response;
        }

        [Route(ApiRoutes.Examiners.DELETE)]
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