import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ShiftsCreateRequestBody } from 'src/app/requests/dashboard/shifts.create.request';
import { ShiftsCreateInfoPositionDto, ShiftsCreateInfoWorkerDto } from 'src/app/responses/dashboard/shifts/create-info.response';
import { ShiftsService } from 'src/app/services/dashboard/shifts/shifts.service';
import { AlertService } from 'src/app/services/shared/alert/alert.service';
import { LoadingService } from 'src/app/services/shared/loading/loading.service';

@Component({
  selector: 'app-shifts.create',
  templateUrl: './shifts.create.component.html',
  styleUrls: ['./shifts.create.component.scss']
})
export class ShiftsCreateComponent implements OnInit {

  positions: ShiftsCreateInfoPositionDto[] = [];
  workers: ShiftsCreateInfoWorkerDto[] = [];

  requestBody: ShiftsCreateRequestBody = new ShiftsCreateRequestBody();

  constructor(
    private shiftsService: ShiftsService,
    private loadingService: LoadingService,
    private router: Router,
    private alertService: AlertService
  ) { }

  ngOnInit(): void {
    this.shiftsService.getCreateInfo().subscribe(
      // Success
      res => {
        this.positions = res.positions;
        this.workers = res.workers;
        this.loadingService.finishedLoading();
      },
      // Error
      err => {
        this.alertService.alertErrorFromStatus(err.status);
        this.router.navigateByUrl("dashboard/calendar");
      }
    );
  }

  onSubmit(){
    this.loadingService.startLoading();
    this.shiftsService.createShift(this.requestBody).subscribe(
      // Success
      () => {
        this.loadingService.finishedLoading();
        this.alertService.alertSuccess("Created Shift");
        this.requestBody = new ShiftsCreateRequestBody();
      },
      // Error
      err => {
        this.loadingService.finishedLoading();
        this.alertService.alertErrorFromStatus(err.status);
      } 
    )
  }
}
