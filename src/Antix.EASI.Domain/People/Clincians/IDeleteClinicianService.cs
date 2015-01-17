﻿using System;
using Antix.Services;
using Antix.Services.Models;

namespace Antix.EASI.Domain.People.Clincians
{
    public interface IDeleteClinicianService :
        IServiceInOut<Guid, IServiceResponse>
    {
    }
}