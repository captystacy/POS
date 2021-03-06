import { Component, Input } from '@angular/core';

import { CalendarPlanService } from './calendar-plan.service';
import { ICalendarWork } from "./calendar-plan.model";

@Component({
  selector: 'app-calendar-plan',
  templateUrl: './calendar-plan.component.html',
  styleUrls: ['./calendar-plan.component.css']
})

export class CalendarPlanComponent {
  @Input() set estimateFiles(value: FileList) {
    this.calendarPlanService.estimateFiles = value;
  }

  constructor(
    public calendarPlanService: CalendarPlanService) {
  }

  public setPercentIfRowMoreThanOneHundred(event: any): number {
    let rowInputs = event.target.closest('tr').getElementsByTagName('input');
    let percentsSum = 0;
    for (let i = 0; i < rowInputs.length; i++) {
      percentsSum += Number(rowInputs[i].value);
    }

    let thisPercent = Number(event.target.value);
    if (percentsSum > 100) {
      let sumOfOtherPercents = percentsSum - thisPercent;
      thisPercent = 100 - sumOfOtherPercents;
      event.target.value = thisPercent;
    }

    return thisPercent;
  }



  public setPercentForColumn(event: any, calendarWorks: ICalendarWork[]): void {
    let newColumnValue = this.setPercentIfRowMoreThanOneHundred(event);
    let tdPosition = event.target.closest('td').cellIndex;

    for (let i = 0; i < this.calendarPlanService.calendarPlan!.mainCalendarWorks.length; i++) {
      calendarWorks[i].percentages[tdPosition].value = newColumnValue;
    }
  }
}
