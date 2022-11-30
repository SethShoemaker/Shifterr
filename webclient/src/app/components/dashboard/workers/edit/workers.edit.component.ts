import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { WorkersEditRequestBody } from 'src/app/requests/dashboard/workers/edit.request';
import { WorkersService } from 'src/app/services/dashboard/workers/workers.service';
import { AlertService } from 'src/app/services/shared/alert/alert.service';
import { LoadingService } from 'src/app/services/shared/loading/loading.service';

@Component({
  selector: 'app-workers-edit',
  templateUrl: './workers.edit.component.html',
  styleUrls: ['./workers.edit.component.scss']
})
export class WorkersEditComponent implements OnInit {

  public userId: number = null!;
  public userName: string = null!;

  public isChangingPassword: boolean = false;

  public isAdmin: boolean = false;

  public requestBody: WorkersEditRequestBody = new WorkersEditRequestBody();

  constructor(
    private workersService: WorkersService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private alertService: AlertService,
    private loadingService: LoadingService
  ) { }

  ngOnInit(): void {
    this.userId = Number(this.activatedRoute.snapshot.paramMap.get('id'));
    if(this.userId == null) this.router.navigateByUrl("dashboard/workers");

    this.workersService.getWorkerInfo(this.userId).subscribe(
      // Success
      res => {
        this.userName = res.userName;
        this.requestBody.email = res.email;
        this.requestBody.nickname = res.nickname;
        if(res.role == "Administrator"){
          this.isAdmin = true;
        }else{
          this.requestBody.role = res.role;
        }
        this.loadingService.finishedLoading();
      },
      // Error
      err => {
        this.loadingService.finishedLoading();
        this.alertService.alertErrorFromStatus(err.status);      
      }
    );
  }

  onSubmit(){
    this.loadingService.startLoading();
    this.workersService.updateWorker(this.userId, this.requestBody).subscribe(
      // Success
      () => {
        this.router.navigateByUrl("dashboard/workers");
        this.alertService.alertSuccess("changes saved for \"" + this.userName + "\"");
      },
      // Error
      err => {
        this.loadingService.finishedLoading();
        this.alertService.alertErrorFromStatus(err.status);
      }
    );
  }
}
