import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PositionsIndexResponseBody } from 'src/app/responses/dashboard/positions/index.response';
import { GenericResponseBody } from 'src/app/responses/generic.response';
import { ApiService } from '../../shared/api/api.service';

@Injectable({
  providedIn: 'root'
})
export class PositionsService {

  constructor(private apiService: ApiService) { }

  getAllPositions(): Observable<any>{
    return this.apiService.get<PositionsIndexResponseBody>("shifts/positions/index");
  }

  deletePosition(id: number){
    return this.apiService.get<GenericResponseBody>("shifts/positions/delete?ShiftPositionId=" + id);
  }
}
