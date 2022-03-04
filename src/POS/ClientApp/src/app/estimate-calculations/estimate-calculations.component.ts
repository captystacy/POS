import { Component } from '@angular/core';

@Component({
  selector: 'app-estimate-calculations',
  templateUrl: './estimate-calculations.component.html',
  styleUrls: ['./estimate-calculations.component.css']
})
export class EstimateCalculationsComponent {
  estimateFiles?: File[];

  estimateFilesSelected(event: any) {
    if (!event.target.files) {
      return;
    }

    this.estimateFiles = event.target.files;
  }
}
