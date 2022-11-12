import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  public apiUrl = environment.apiUrl;

  constructor(private httpClient: HttpClient) { }

  get<T>(path: string, params: HttpParams = new HttpParams()): Observable<any> 
  {
    return this.httpClient.get<T>(
      `${this.apiUrl}${path}`, 
      { params }
    );
  }

  put<T>(path: string, body: Object = {}): Observable<any> 
  {
    return this.httpClient.put<T>(
      `${this.apiUrl}${path}`,
      body
    );
  }

  post<T>(path: string, body: Object = {}): Observable<any> 
    {
    return this.httpClient.post<T>(
      `${this.apiUrl}${path}`,
      body
    );
  }

  delete<T>(path: string): Observable<any> 
  {
    return this.httpClient.delete<T>(
      `${this.apiUrl}${path}`
    );
  }
}
