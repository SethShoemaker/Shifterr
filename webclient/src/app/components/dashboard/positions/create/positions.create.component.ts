import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PositionsCreateRequestBody } from 'src/app/requests/dashboard/positions/create.request';
import { PositionsService } from 'src/app/services/dashboard/positions/positions.service';

@Component({
  selector: 'app-positions-create',
  templateUrl: './positions.create.component.html',
  styleUrls: ['./positions.create.component.scss']
})
export class PositionsCreateComponent implements OnInit {

  public requestBody: PositionsCreateRequestBody = new PositionsCreateRequestBody();

  public alertIsActive: boolean = false;
  public alertMessage: string = null!;

  constructor(
    private positionService: PositionsService,
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
    this.positionService.createPosition(this.requestBody).subscribe(
      // Success
      res => {
        this.router.navigateByUrl("dashboard/positions");
      },
      // Error
      () => {
        this.createAlert("Could Not Create Position");
      }
    )
  }
}
