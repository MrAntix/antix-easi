﻿using Antix.EASI.Domain.People.Clincians.Models;
using Antix.Services;
using Antix.Services.Models;

namespace Antix.EASI.Domain.People.Clincians
{
    public interface ILookupCliniciansService :
        IServiceOut<IServiceResponse<ClinicianInfoModel[]>>
    {
    }
}