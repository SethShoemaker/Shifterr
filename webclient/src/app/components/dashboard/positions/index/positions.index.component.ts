import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { delay } from 'rxjs';
import { PositionsIndexResponseBody } from 'src/app/responses/dashboard/positions/index.response';
import { RoleService } from 'src/app/services/auth/role/role.service';
import { PositionsService } from 'src/app/services/dashboard/positions/positions.service';
import { AlertService } from 'src/app/services/shared/alert/alert.service';
import { LoadingService } from 'src/app/services/shared/loading/loading.service';

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

  public confirmationIsActive: boolean = false;
  public positionIdToRemove: number = null!;

  public searchQueryLowercase: string = null!;

  constructor(
    private positionsService: PositionsService,
    private router: Router,
    private roleService: RoleService,
    private alertService: AlertService,
    private loadingService: LoadingService
  ) { }

  ngOnInit(): void {
    this.getPositions();
    this.loadingService.finishedLoading();
  }

  getPositions(){
    this.positionsService.getAllPositions().subscribe(
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
    );
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

  removePosition(id: number){
    this.positionsToStore = this.positionsToStore.filter(p => p.id != id);
    this.positionsToDisplay = this.positionsToDisplay.filter(p => p.id != id);
  }

  confirmDeletion(){
    this.loadingService.startLoading();
    this.positionsService.deletePosition(this.positionIdToRemove).subscribe(
      // Success
      () => {
        var position: PositionsIndexResponseBody | undefined = this.positionsToStore.filter(p => p.id == this.positionIdToRemove).pop();
        this.removePosition(this.positionIdToRemove);
        this.removeDeleteConfirmation();
        this.loadingService.finishedLoading();
        this.alertService.alertSuccess("deleted \"" + position?.name + "\"");
      },
      // Error
      err => {
        this.loadingService.finishedLoading();
        this.alertService.alertErrorFromStatus(err.status);
      }
    );
  }
}
