import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ShiftShowResponseBody } from 'src/app/responses/dashboard/shifts/show.response';
import { ShiftsService } from 'src/app/services/dashboard/shifts/shifts.service';
import { AlertService } from 'src/app/services/shared/alert/alert.service';
import { LoadingService } from 'src/app/services/shared/loading/loading.service';

@Component({
  selector: 'app-shifts-show',
  templateUrl: './shifts.show.component.html',
  styleUrls: ['./shifts.show.component.scss']
})
export class ShiftsShowComponent implements OnInit {

  @Output() removeEmitter: EventEmitter<any> = new EventEmitter<any>();

  @Input() shiftId: number = null!;
  shiftDetails: ShiftShowResponseBody = null!;

  contentIsActive: boolean = false;

  constructor(
    private loadingService: LoadingService,
    private shiftsService: ShiftsService,
    private alertService: AlertService
  ) { }

  ngOnInit(): void {
    this.loadingService.startLoading();
    this.shiftsService.getShiftInfo(this.shiftId).subscribe(
      // Success
      res => {
        this.loadingService.finishedLoading();
        this.contentIsActive = true;
        this.shiftDetails = res;
        console.log(this.shiftDetails);
      },
      err => {
        this.loadingService.finishedLoading();
        this.alertService.alertErrorFromStatus(err.status);
      }
    );
  }

  remove(){
    this.removeEmitter.emit();
  }
}
