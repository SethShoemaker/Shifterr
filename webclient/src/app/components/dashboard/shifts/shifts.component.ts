import { Component, OnInit } from '@angular/core';
import { ShiftsService } from 'src/app/services/dashboard/shifts/shifts.service';
import { ShiftIndexResponseBody } from 'src/app/responses/dashboard/shifts/index.response';

@Component({
  selector: 'app-shifts',
  templateUrl: './shifts.component.html',
  styleUrls: ['./shifts.component.scss']
})
export class ShiftsComponent implements OnInit {

  public shifts: ShiftIndexResponseBody[] = [];

  constructor(private shiftsService: ShiftsService) { }

  ngOnInit(): void {
    this.GetShifts();
  }

  GetShifts(){
    var shifts = this.shiftsService.getAllShifts().subscribe(
      // Success
      res => {
        this.shifts = res.shifts;
      }
    )
  }
}
