import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ShiftIndexResponseBody } from 'src/app/responses/dashboard/shifts/index.response';
import { ApiService } from '../../shared/api/api.service';

@Injectable({
  providedIn: 'root'
})
export class ShiftsService {

  constructor(private apiService: ApiService) { }

  getAllShifts(): Observable<any>{
    return this.apiService.get<ShiftIndexResponseBody>("shifts/index");
  }
}