import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ShiftsCreateRequestBody } from 'src/app/requests/dashboard/shifts.create.request';
import { CalendarIndexResponse } from 'src/app/responses/dashboard/calendar/index.response';
import { ShiftsCreateInfoResponseBody } from 'src/app/responses/dashboard/shifts/create-info.response';
import { ShiftIndexResponseBody } from 'src/app/responses/dashboard/shifts/index.response';
import { GenericResponseBody } from 'src/app/responses/generic.response';
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

  // Gets information needed to create shift, information like user IDs and names
  getCreateInfo(): Observable<any>{
    return this.apiService.get<ShiftsCreateInfoResponseBody>("shifts/create/info");
  }

  createShift(requestBody: ShiftsCreateRequestBody): Observable<any>{
    return this.apiService.post<GenericResponseBody>("shifts/create", requestBody);
  }
}