import { Component, OnInit } from '@angular/core';
import { ShiftsService } from 'src/app/services/dashboard/shifts/shifts.service';
import { ShiftIndexResponseBody } from 'src/app/responses/dashboard/shifts/index.response';
import { AlertService } from 'src/app/services/shared/alert/alert.service';

@Component({
  selector: 'app-shifts-index',
  templateUrl: './shifts.index.component.html',
  styleUrls: ['./shifts.index.component.scss']
})
export class ShiftsIndexComponent implements OnInit {

  public shifts: ShiftIndexResponseBody[] = [];

  constructor(
    private shiftsService: ShiftsService,
    private alertService: AlertService
  ) { }

  ngOnInit(): void {
    this.GetShifts();
  }

  GetShifts(){
    this.shiftsService.getAllShifts().subscribe(
      // Success
      res => {
        this.shifts = res.shifts;
      },
      // Error
      err => {
        this.alertService.alertErrorFromStatus(err.status);
      }
    )
  }
}
