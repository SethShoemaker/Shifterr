import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PositionsEditRequestBody } from 'src/app/requests/dashboard/positions/edit.request';
import { PositionsService } from 'src/app/services/dashboard/positions/positions.service';

@Component({
  selector: 'app-positions.edit',
  templateUrl: './positions.edit.component.html',
  styleUrls: ['./positions.edit.component.scss']
})
export class PositionsEditComponent implements OnInit {

  positionId: number = null!;

  requestBody: PositionsEditRequestBody = new PositionsEditRequestBody();

  alertIsActive: boolean = false;
  alertMessage: string = null!;

  constructor(
    private positionsService: PositionsService,
    private activatedRoute: ActivatedRoute,
    private router: Router
    ) { }

  ngOnInit(): void {
    this.positionId = Number(this.activatedRoute.snapshot.paramMap.get('id'));
    if(this.positionId == null) this.router.navigateByUrl("dashboard/workers");
    
    this.positionsService.getPositionInfo(this.positionId).subscribe(
      // Success
      res => {
        this.requestBody.name = res.name,
        this.requestBody.description = res.description
      },
      // Error 
      () => {
        this.createAlert("Could Not Save Changes");
      }
    );
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
    this.positionsService.updatePositionInfo(this.positionId, this.requestBody).subscribe(
      // Success
      () => {
        this.router.navigateByUrl("dashboard/positions");
      },
      // Error
      () => {
        this.createAlert("Could Not Save Changes");
      }
    )
  }

}