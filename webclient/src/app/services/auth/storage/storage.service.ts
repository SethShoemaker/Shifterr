import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  private tokenStorageLocation: string = "ShifterrAuthToken";
  private organizationNameStorageLocation: string = "ShifterrOrganizationName";

  constructor() { }

  storeToken(token:string): void{
    localStorage.setItem(this.tokenStorageLocation, token);
  }

  hasToken(): boolean{
    return localStorage.getItem(this.tokenStorageLocation) != null;
  }

  deleteToken(): void{
    localStorage.removeItem(this.tokenStorageLocation);
  }

  storeOrganizationName(token:string): void{
    localStorage.setItem(this.organizationNameStorageLocation, token);
  }

  hasOrganizationName(): boolean{
    return localStorage.getItem(this.organizationNameStorageLocation) != null;
  }

  getOrganizationName(): string | null{
    return localStorage.getItem(this.organizationNameStorageLocation);
  }

  deleteOrganizationName(): void{
    localStorage.removeItem(this.organizationNameStorageLocation);
  }

  hasTokenAndOrganizationName(): boolean{
    return this.hasToken() && this.hasOrganizationName();
  }
}
