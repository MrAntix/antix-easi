﻿using Antix.EASI.Domain.Examinations.Models;
using Antix.Services;
using Antix.Services.Models;

namespace Antix.EASI.Domain.Examinations
{
    public interface ISearchExaminationsService :
        IServiceInOut<SearchExaminationsModel, IServiceResponse<SearchExaminationsResultModel>>
    {
    }
}