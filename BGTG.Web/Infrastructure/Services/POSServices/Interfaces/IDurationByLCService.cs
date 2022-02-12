﻿using BGTG.POS.DurationTools.DurationByLCTool;
using BGTG.Web.ViewModels.POSViewModels.DurationByLCViewModels;

namespace BGTG.Web.Infrastructure.Services.POSServices.Interfaces
{
    public interface IDurationByLCService : ISavable
    {
        DurationByLC Write(DurationByLCCreateViewModel viewModel, string identityName);
        DurationByLC Write(DurationByLC durationByLC, string identityName);
    }
}
