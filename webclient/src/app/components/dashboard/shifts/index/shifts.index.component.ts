import { Component, OnInit } from '@angular/core';
import { ShiftsService } from 'src/app/services/dashboard/shifts/shifts.service';
import { ShiftIndexResponseBody } from 'src/app/responses/dashboard/shifts/index.response';
import { AlertService } from 'src/app/services/shared/alert/alert.service';
import { LoadingService } from 'src/app/services/shared/loading/loading.service';

@Component({
  selector: 'app-shifts-index',
  templateUrl: './shifts.index.component.html',
  styleUrls: ['./shifts.index.component.scss']
})
export class ShiftsIndexComponent implements OnInit {

  public shifts: ShiftIndexResponseBody[] = [];

  constructor(
    private shiftsService: ShiftsService,
    private alertService: AlertService,
    private loadingService: LoadingService
  ) { }

  ngOnInit(): void {
    this.GetShifts();
    this.loadingService.finishedLoading();
  }

  GetShifts(){
    this.shiftsService.getAllShifts().subscribe(
      // Success
      res => {
        this.shifts = res.shifts;
        if(this.shifts.length == 0) this.alertService.alertSuccess("No shifts to display");
        this.loadingService.finishedLoading();
      },
      // Error
      err => {
        this.loadingService.finishedLoading();
        this.alertService.alertErrorFromStatus(err.status);
      }
    )
  }
}
