import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PositionsIndexResponseBody } from 'src/app/responses/dashboard/positions/index.response';
import { PositionsService } from 'src/app/services/dashboard/positions/positions.service';

@Component({
  selector: 'app-positions-index',
  templateUrl: './positions.index.component.html',
  styleUrls: ['./positions.index.component.scss']
})
export class PositionsIndexComponent implements OnInit {

  public positionsToStore: PositionsIndexResponseBody[] = [];
  public positionsToDisplay:  PositionsIndexResponseBody[] = [];

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
    this.GetPositionsToStore();
  }

  GetPositionsToStore(){
    var shifts = this.positionsService.getAllPositions().subscribe(
      // Success
      res => {
        this.positionsToStore = res.positions;
        this.positionsToDisplay = this.positionsToStore;
      },
      // Error
      err => {
        this.createAlert("Could Not Get Shifts");
      }
    )
  }

  searchPositions(query: string){
    this.positionsToDisplay = this.positionsToStore.filter(p => {
      var positionNameToLower = p.name.toLowerCase();
      var searchQueryToLower = query.toLowerCase();
      return positionNameToLower.includes(searchQueryToLower);
    })
  }

  onAddClick(){
    this.router.navigateByUrl("dashboard/shifts");
  }

  createDeleteConfirmation(id: number){
    this.positionIdToRemove = id;
    this.confirmationIsActive = true;
  }

  removeDeleteConfirmation(){
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
    this.positionsToStore = this.positionsToStore.filter(p => p.id != id);
  }

  confirmDeletion(){
    this.positionsService.deletePosition(this.positionIdToRemove).subscribe(
      // Success
      res => {
        this.removePosition(this.positionIdToRemove);
        this.removeDeleteConfirmation();
      },
      // Error
      err => {
        this.createAlert("Could Not Delete Position");
        this.removeDeleteConfirmation();
      }
    );
  }
}
