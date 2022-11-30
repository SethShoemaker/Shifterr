import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { WorkersIndexResponseBody } from 'src/app/responses/dashboard/workers/index.response';
import { RoleService } from 'src/app/services/auth/role/role.service';
import { WorkersService } from 'src/app/services/dashboard/workers/workers.service';
import { AlertService } from 'src/app/services/shared/alert/alert.service';
import { LoadingService } from 'src/app/services/shared/loading/loading.service';

@Component({
  selector: 'app-workers-index',
  templateUrl: './workers.index.component.html',
  styleUrls: ['./workers.index.component.scss']
})
export class WorkersIndexComponent implements OnInit {

  public workersToStore: WorkersIndexResponseBody[] = [];
  public workersToDisplay: WorkersIndexResponseBody[] = [];

  public tableTopic: string = "Worker";
  public createVerb: string = "Register";
  public canEdit: boolean = this.roleService.isAdmin();

  public confirmationIsActive: boolean = false;
  public workerIdToRemove: number = null!;

  public searchQueryLowercase: string = null!;

  constructor(
    private workersService: WorkersService,
    private roleService: RoleService,
    private router: Router,
    private alertService: AlertService,
    private loadingService: LoadingService
  ) { }

  ngOnInit(): void {
    this.getWorkers();
    this.loadingService.finishedLoading();
  }

  getWorkers(){
    this.loadingService.startLoading();
    this.workersService.getAllWorkers().subscribe(
      // Success
      res => {
        this.workersToStore = res.workers;
        this.workersToDisplay = this.workersToStore;
        this.filterWorkers();
        this.loadingService.finishedLoading();
      },
      // Error
      err => {
        this.loadingService.finishedLoading();
        this.alertService.alertErrorFromStatus(err.status);
      }
    )
  }

  setSearchQueryAndFilterWorkers(query: string){
    this.searchQueryLowercase = query.toLowerCase();
    this.filterWorkers();
  }

  filterWorkers(){
    if(this.searchQueryLowercase == null){
      this.workersToDisplay = this.workersToStore;
    }
    else{
      this.workersToDisplay = this.workersToStore.filter(p => {
        var workerNameToLower = p.nickname.toLowerCase();
        var workerEmailToLower = p.email.toLowerCase();
        return (workerNameToLower.includes(this.searchQueryLowercase)) || (workerEmailToLower.includes(this.searchQueryLowercase));
      })
    }
  }

  createDeleteConfirmation(id: number){
    this.workerIdToRemove = id;
    this.confirmationIsActive = true;
  }

  removeDeleteConfirmation(){
    this.workerIdToRemove = null!;
    this.confirmationIsActive = false;
  }

  removeWorker(id: number){
    this.workersToStore = this.workersToStore.filter(p => p.id != id);
    this.workersToDisplay = this.workersToDisplay.filter(p => p.id != id);
  }

  confirmDeletion(){
    this.workersService.deleteWorker(this.workerIdToRemove).subscribe(
      // Success
      () => {
        var worker = this.workersToStore.filter(p => p.id == this.workerIdToRemove).pop();
        this.removeWorker(this.workerIdToRemove);
        this.removeDeleteConfirmation();
        this.alertService.alertSuccess("deleted \"" + worker?.nickname + "\"");
        this.loadingService.finishedLoading();
      },
      // Error
      err => {
        this.loadingService.finishedLoading();
        this.alertService.alertErrorFromStatus(err.status);
      }
    );
  }

  onAddClick(){
    this.router.navigateByUrl("dashboard/workers/register");
  }

  onEditClick(id: number){
    this.router.navigate(['/dashboard/workers/edit', id]);
  }
}
