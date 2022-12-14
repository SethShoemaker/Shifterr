import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { WorkersCreateRequestBody } from 'src/app/requests/dashboard/workers/create.request';
import { WorkersService } from 'src/app/services/dashboard/workers/workers.service';
import { AlertService } from 'src/app/services/shared/alert/alert.service';
import { LoadingService } from 'src/app/services/shared/loading/loading.service';

@Component({
  selector: 'app-workers-create',
  templateUrl: './workers.create.component.html',
  styleUrls: ['./workers.create.component.scss']
})
export class WorkersCreateComponent implements OnInit {

  public alertMessage: string = null!;
  public alertIsActive: boolean = false;

  public requestBody: WorkersCreateRequestBody = new WorkersCreateRequestBody();

  constructor(
    private workersService: WorkersService,
    private router: Router,
    private alertService: AlertService,
    private loadingService: LoadingService
    ) { }

  ngOnInit(): void {
    this.loadingService.finishedLoading();
  }

  onSubmit(){
    this.workersService.registerWorker(this.requestBody).subscribe(
      // Success
      () => {
        this.router.navigateByUrl("dashboard/workers");
        this.alertService.alertSuccess("registered \"" + this.requestBody.nickname + "\"");
      },
      // Error
      err => {
        this.loadingService.finishedLoading();
        this.alertService.alertErrorFromStatus(err.status);
      }
    )
  }
}
