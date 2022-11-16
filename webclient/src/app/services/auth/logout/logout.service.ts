import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { StorageService } from '../storage/storage.service';

@Injectable({
  providedIn: 'root'
})
export class LogoutService {

  constructor(
    private storageService: StorageService,
    private router: Router
    ) { }

  logout(): void{
    this.storageService.deleteAllAuthDetails();
    this.router.navigateByUrl("/");
  }
}
