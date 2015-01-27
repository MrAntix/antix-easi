﻿using System;
using Antix.EASI.Domain.People.Examiners.Models;
using Antix.Services;
using Antix.Services.Models;

namespace Antix.EASI.Domain.People.Examiners
{
    public interface ICreateExaminerService :
        IServiceInOut<CreateExaminerModel, IServiceResponse<Guid>>
    {
    }
}