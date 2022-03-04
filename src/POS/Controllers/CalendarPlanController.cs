﻿using Calabonga.OperationResults;
using Microsoft.AspNetCore.Mvc;
using POS.Infrastructure.Attributes;
using POS.Infrastructure.Services.Base;
using POS.ViewModels;

namespace POS.Controllers;

[Route("api/[controller]")]
public class CalendarPlanController : ControllerBase
{
    private readonly ICalendarPlanService _calendarPlanService;

    public CalendarPlanController(ICalendarPlanService calendarPlanService)
    {
        _calendarPlanService = calendarPlanService;
    }

    [HttpPost("[action]")]
    //[ValidateModelState]
    public OperationResult<CalendarPlanViewModel> GetViewModelForCreation([FromForm] CalendarPlanCreateViewModel viewModel)
    {
        var operation = OperationResult.CreateResult<CalendarPlanViewModel>();

        operation.Result = _calendarPlanService.GetCalendarPlanViewModel(viewModel);

        return operation;
    }

    [HttpPost("[action]")]
    [ValidateModelState]
    public OperationResult<IEnumerable<decimal>> GetTotalPercentages(CalendarPlanViewModel viewModel)
    {
        var operation = OperationResult.CreateResult<IEnumerable<decimal>>();

        operation.Result = _calendarPlanService.GetTotalPercentages(viewModel);

        return operation;
    }

    [HttpPost("[action]")]
    [ValidateModelState]
    public IActionResult GetFile(CalendarPlanViewModel viewModel)
    {
        var operation = OperationResult.CreateResult<CalendarPlanViewModel>();
        operation.Result = viewModel;

        var fileStream = _calendarPlanService.Write(viewModel);

        return File(fileStream, AppData.DocxMimeType);
    }
}