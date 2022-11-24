import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { WorkersEditRequestBody } from 'src/app/requests/dashboard/workers/edit.request';
import { WorkersService } from 'src/app/services/dashboard/workers/workers.service';

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

  public alertIsActive: boolean = false;
  public alertMessage: string = null!;

  public requestBody: WorkersEditRequestBody = new WorkersEditRequestBody();

  constructor(
    private workersService: WorkersService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.userId = Number(this.activatedRoute.snapshot.paramMap.get('id'));
    if(this.userId == null) this.router.navigateByUrl("dashboard/workers");

    this.workersService.getWorkerInfo(this.userId).subscribe(
      // Success
      res => {
        this.userName = res.userName;
        this.requestBody.email = res.email;
        if(res.organizationRole == "Administrator"){
          this.isAdmin = true;
        }else{
          this.requestBody.organizationRole = res.organizationRole;
        }
      },
      // Error
      () => {
        this.router.navigateByUrl("dashboard/workers");
      }
    );
  }

  onSubmit(){
    this.workersService.updateWorker(this.userId, this.requestBody).subscribe(
      // Success
      res => {
        this.router.navigateByUrl("dashboard/workers");
      },
      // Error
      () => {
        console.log("error");
      }
    );
  }
}
