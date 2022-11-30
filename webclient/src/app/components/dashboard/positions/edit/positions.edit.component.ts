import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PositionsEditRequestBody } from 'src/app/requests/dashboard/positions/edit.request';
import { PositionsService } from 'src/app/services/dashboard/positions/positions.service';
import { AlertService } from 'src/app/services/shared/alert/alert.service';
import { LoadingService } from 'src/app/services/shared/loading/loading.service';

@Component({
  selector: 'app-positions.edit',
  templateUrl: './positions.edit.component.html',
  styleUrls: ['./positions.edit.component.scss']
})
export class PositionsEditComponent implements OnInit {

  positionId: number = null!;

  requestBody: PositionsEditRequestBody = new PositionsEditRequestBody();

  constructor(
    private positionsService: PositionsService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private alertService: AlertService,
    private loadingService: LoadingService
    ) { }

  ngOnInit(): void {
    this.positionId = Number(this.activatedRoute.snapshot.paramMap.get('id'));
    if(this.positionId == null) this.router.navigateByUrl("dashboard/workers");
    
    this.positionsService.getPositionInfo(this.positionId).subscribe(
      // Success
      res => {
        this.requestBody.name = res.name;
        this.requestBody.description = res.description;
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
    this.positionsService.updatePositionInfo(this.positionId, this.requestBody).subscribe(
      // Success
      () => {
        this.router.navigateByUrl("dashboard/positions");
        this.alertService.alertSuccess("changes saved");
      },
      // Error
      err => {
        this.loadingService.finishedLoading();
        this.alertService.alertErrorFromStatus(err.status);
      }
    )
  }

}