﻿using BGTG.Web.Infrastructure.Services;
using BGTG.Web.Infrastructure.Services.BGTG;
using BGTG.Web.Infrastructure.Services.BGTG.Base;
using Microsoft.Extensions.DependencyInjection;

namespace BGTG.Web.Infrastructure.DependencyInjection;

public partial class DependencyContainer
{
    public static void BGTG(IServiceCollection services)
    {
        services.AddScoped<IConstructionObjectService, ConstructionObjectService>();
    }
}