import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RequestConfirmationRequestBody } from 'src/app/requests/request-confirmation.request';
import { GenericResponseBody } from 'src/app/responses/generic.response';
import { ApiService } from '../../shared/api/api.service';

@Injectable({
  providedIn: 'root'
})
export class RequestConfirmationService {

  constructor(private apiService: ApiService) { }

  requestConfirmation(requestBody: RequestConfirmationRequestBody): Observable<any>{
    return this.apiService.post<GenericResponseBody>('user/confirmation/send', requestBody);
  }
}
