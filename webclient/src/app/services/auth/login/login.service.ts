import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginRequestBody } from 'src/app/requests/login.request';
import { LoginResponseBody } from 'src/app/responses/login.response';
import { ApiService } from '../../shared/api/api.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(
    private apiService: ApiService
  ) { }

  attemptLogin(loginRequestBody: LoginRequestBody): Observable<any>
  {
    return this.apiService.post<LoginResponseBody>(
      'user/login', 
      loginRequestBody
    );
  }
}
