import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PositionsCreateRequestBody } from 'src/app/requests/dashboard/positions/create.request';
import { PositionsService } from 'src/app/services/dashboard/positions/positions.service';
import { AlertService } from 'src/app/services/shared/alert/alert.service';
import { LoadingService } from 'src/app/services/shared/loading/loading.service';

@Component({
  selector: 'app-positions-create',
  templateUrl: './positions.create.component.html',
  styleUrls: ['./positions.create.component.scss']
})
export class PositionsCreateComponent implements OnInit {

  public requestBody: PositionsCreateRequestBody = new PositionsCreateRequestBody();

  constructor(
    private positionService: PositionsService,
    private router: Router,
    private alertService: AlertService,
    private loadingService: LoadingService
  ) { }

  ngOnInit(): void {
    this.loadingService.finishedLoading();
  }

  onSubmit(){
    this.loadingService.startLoading();
    this.positionService.createPosition(this.requestBody).subscribe(
      // Success
      () => {
        this.router.navigateByUrl("dashboard/positions");
        this.alertService.alertSuccess("created \"" + this.requestBody.name + "\" position");
      },
      // Error
      err => {
        this.loadingService.finishedLoading();
        this.alertService.alertErrorFromStatus(err.status);
      }
    )
  }
}
