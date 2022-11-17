import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PositionsIndexResponseBody } from 'src/app/responses/dashboard/positions/index.response';
import { PositionsService } from 'src/app/services/dashboard/positions/positions.service';

@Component({
  selector: 'app-positions',
  templateUrl: './positions.component.html',
  styleUrls: ['./positions.component.scss']
})
export class PositionsComponent implements OnInit {

  public positions: PositionsIndexResponseBody[] = [];

  public tableTopic: string = "Position";

  public alertIsActive: boolean = false;
  public alertMessage: string = null!;

  public confirmationIsActive: boolean = false;

  public positionIdToRemove: number = null!;

  constructor(
    private positionsService: PositionsService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.GetPositions();
    this.createAlert("Message");
  }

  GetPositions(){
    var shifts = this.positionsService.getAllPositions().subscribe(
      // Success
      res => {
        this.positions = res.positions;
      },
      // Error
      err => {
        this.createAlert("Could Not Get Shifts");
      }
    )
  }

  onAddClick(){
    this.router.navigateByUrl("dashboard/shifts");
  }

  createConfirmation(id: number){
    this.positionIdToRemove = id;
    this.confirmationIsActive = true;
  }

  removeConfirmation(){
    this.positionIdToRemove = null!;
    this.confirmationIsActive = false;
  }

  createAlert(message: string){
    this.alertMessage = message;
    this.alertIsActive = true;
  }

  removeAlert(){
    this.alertMessage = null!;
    this.alertIsActive = false;
  }

  removePosition(id: number){
    this.positions = this.positions.filter(p => p.id != id);
  }

  confirmDeletion(){
    this.positionsService.deletePosition(this.positionIdToRemove).subscribe(
      // Success
      res => {
        this.removePosition(this.positionIdToRemove);
      },
      // Error
      err => {
        this.createAlert("Could Not Delete Position");
      }
    );
    
    this.removeConfirmation();
  }
}
