import { Component, OnInit } from '@angular/core';
import { PositionsIndexResponseBody } from 'src/app/responses/dashboard/positions/index.response';
import { PositionsService } from 'src/app/services/dashboard/positions/positions.service';

@Component({
  selector: 'app-positions',
  templateUrl: './positions.component.html',
  styleUrls: ['./positions.component.scss']
})
export class PositionsComponent implements OnInit {

  public positions: PositionsIndexResponseBody[] = [];

  constructor(private positionsService: PositionsService) { }

  ngOnInit(): void {
    this.GetShifts();
  }

  GetShifts(){
    var shifts = this.positionsService.getAllPositions().subscribe(
      // Success
      res => {
        this.positions = res.positions;
      }
    )
  }
}
