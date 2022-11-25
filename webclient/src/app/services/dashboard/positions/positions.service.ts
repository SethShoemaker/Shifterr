import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PositionsEditRequestBody } from 'src/app/requests/dashboard/positions/edit.request';
import { PositionsCreateRequestBody } from 'src/app/requests/dashboard/positions/create.request';
import { PositionsIndexResponseBody } from 'src/app/responses/dashboard/positions/index.response';
import { PositionsInfoResponseBody } from 'src/app/responses/dashboard/positions/info.response';
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

  getPositionInfo(id: number){
    return this.apiService.get<PositionsInfoResponseBody>("shifts/positions/info?ShiftPositionId=" + id);
  }

  updatePositionInfo(id: number, requestBody: PositionsEditRequestBody){
    return this.apiService.post<GenericResponseBody>("shifts/positions/update?ShiftPositionId=" + id, requestBody);
  }

  deletePosition(id: number){
    return this.apiService.get<GenericResponseBody>("shifts/positions/delete?ShiftPositionId=" + id);
  }

  createPosition(requestBody: PositionsCreateRequestBody){
    return this.apiService.post<GenericResponseBody>("shifts/positions/create", requestBody);
  }
}
