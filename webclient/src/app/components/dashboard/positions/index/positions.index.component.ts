import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PositionsIndexResponseBody } from 'src/app/responses/dashboard/positions/index.response';
import { RoleService } from 'src/app/services/auth/role/role.service';
import { PositionsService } from 'src/app/services/dashboard/positions/positions.service';
import { AlertService } from 'src/app/services/shared/alert/alert.service';

@Component({
  selector: 'app-positions-index',
  templateUrl: './positions.index.component.html',
  styleUrls: ['./positions.index.component.scss']
})
export class PositionsIndexComponent implements OnInit {

  public positionsToStore: PositionsIndexResponseBody[] = [];
  public positionsToDisplay:  PositionsIndexResponseBody[] = [];

  public tableTopic: string = "Position";
  public canEdit: boolean = this.roleService.isManager();

  public alertIsActive: boolean = false;
  public alertMessage: string = null!;

  public confirmationIsActive: boolean = false;
  public positionIdToRemove: number = null!;

  public searchQueryLowercase: string = null!;

  constructor(
    private positionsService: PositionsService,
    private router: Router,
    private roleService: RoleService,
    private alertService: AlertService
  ) { }

  ngOnInit(): void {
    this.getPositions();
  }

  getPositions(){
    var shifts = this.positionsService.getAllPositions().subscribe(
      // Success
      res => {
        this.positionsToStore = res.positions;
        this.positionsToDisplay = this.positionsToStore;
        this.filterPositions();
      },
      // Error
      err => {
        this.alertService.alertErrorFromStatus(err.status);
      }
    )
  }

  filterPositions(){
    if(this.searchQueryLowercase == null){
      this.positionsToDisplay = this.positionsToStore;
    }
    else{
      this.positionsToDisplay = this.positionsToStore.filter(p => {
        var positionNameToLower = p.name.toLowerCase();
        return positionNameToLower.includes(this.searchQueryLowercase);
      })
    }
  }

  setSearchQueryAndFilterPositions(query: string){
    this.searchQueryLowercase = query.toLowerCase();
    this.filterPositions();
  }

  onAddClick(){
    this.router.navigateByUrl("dashboard/positions/create");
  }

  onEditClick(id: number){
    this.router.navigate(['/dashboard/positions/edit', id]);
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
    this.positionsToDisplay = this.positionsToDisplay.filter(p => p.id != id);
  }

  confirmDeletion(){
    this.positionsService.deletePosition(this.positionIdToRemove).subscribe(
      // Success
      () => {
        var position: PositionsIndexResponseBody | undefined = this.positionsToStore.filter(p => p.id == this.positionIdToRemove).pop();
        this.alertService.alertSuccess("deleted \"" + position?.name + "\"");
        this.removePosition(this.positionIdToRemove);
        this.removeDeleteConfirmation();
      },
      // Error
      err => {
        this.alertService.alertErrorFromStatus(err.status);
      }
    );
  }
}
