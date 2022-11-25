import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { WorkersCreateRequestBody } from 'src/app/requests/dashboard/workers/create.request';
import { WorkersService } from 'src/app/services/dashboard/workers/workers.service';

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
    private router: Router
    ) { }

  ngOnInit(): void {
  }

  createAlert(message: string){
    this.alertMessage = message;
    this.alertIsActive = true;
  }

  removeAlert(){
    this.alertMessage = null!;
    this.alertIsActive = false;
  }

  onSubmit(){
    this.workersService.registerWorker(this.requestBody).subscribe(
      // Success
      () => {
        this.router.navigateByUrl("dashboard/workers");
      },
      // Error
      () => {
        this.createAlert("Couldn't register worker");
      }
    )
  }
}
