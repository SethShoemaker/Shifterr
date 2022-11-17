import { Component, OnInit } from '@angular/core';
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

  public deleteConfirmIsActive: boolean = false;

  constructor(
    private positionsService: PositionsService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.GetPositions();
  }

  GetPositions(){
    var shifts = this.positionsService.getAllPositions().subscribe(
      // Success
      res => {
        this.positions = res.positions;
      }
    )
  }

  onAddClick(){
    this.router.navigateByUrl("dashboard/shifts");
  }

  delete(){
    this.deleteConfirmIsActive = !this.deleteConfirmIsActive;
  }
}
