﻿namespace POS.Infrastructure.Tools.DurationTools.DurationByLCTool.Base;

public interface IDurationByLCCreator
{
    DurationByLC Create(decimal estimateLaborCosts, decimal technologicalLaborCosts, decimal workingDayDuration, decimal shift, decimal numberOfWorkingDaysInMonth, int numberOfEmployees, bool acceptanceTimeIncluded);
}