import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CalendarIndexResponse } from 'src/app/responses/dashboard/calendar/index.response';
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

  getCalendarShifts(from: string, to: string): Observable<any>{
    return this.apiService.get<CalendarIndexResponse>(`calendar/index?From=${from}&To=${to}`);
  }
}