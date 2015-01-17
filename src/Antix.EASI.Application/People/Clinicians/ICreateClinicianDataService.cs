﻿using System;
using Antix.EASI.Domain.People.Clincians.Models;
using Antix.Services;

namespace Antix.EASI.Application.People.Clinicians
{
    public interface ICreateClinicianDataService :
        IServiceInOut<CreateClinicianModel, Guid>
    {
    }
}