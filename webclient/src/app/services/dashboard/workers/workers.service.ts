import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WorkersCreateRequestBody } from 'src/app/requests/dashboard/workers/create.request';
import { WorkersEditRequestBody } from 'src/app/requests/dashboard/workers/edit.request';
import { WorkersIndexResponseBody } from 'src/app/responses/dashboard/workers/index.response';
import { WorkerInfoResponseBody } from 'src/app/responses/dashboard/workers/info.response';
import { ApiService } from '../../shared/api/api.service';

@Injectable({
  providedIn: 'root'
})
export class WorkersService {

  constructor(private apiService: ApiService) { }

  getAllWorkers(): Observable<any>{
    return this.apiService.get<WorkersIndexResponseBody>("user/index");
  }

  getWorkerInfo(id: number){
    return this.apiService.get<WorkerInfoResponseBody>("user/info?UserId=" + id);
  }

  updateWorker(id: number, request: WorkersEditRequestBody){
    return this.apiService.post("user/update?UserId=" + id, request);
  }

  deleteWorker(id: number){
    return this.apiService.get("user/delete?UserId=" + id);
  }

  registerWorker(requestBody: WorkersCreateRequestBody){
    return this.apiService.post("user/register", requestBody);
  }
}
