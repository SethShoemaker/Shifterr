import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { StorageService } from 'src/app/services/auth/storage/storage.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private storageService: StorageService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler) {
    var authToken = this.storageService.getToken();

    if(authToken == null){
      return next.handle(request);
    }else{
      authToken = "Bearer " + authToken.toString();
    }

    const authRequest = request.clone({
      headers: request.headers.set('Authorization', authToken)
    });

    return next.handle(authRequest);
  }
}
