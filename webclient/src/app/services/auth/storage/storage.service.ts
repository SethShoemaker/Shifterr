import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  private tokenStorageLocation: string = "ShifterrAuthToken";
  private organizationNameStorageLocation: string = "ShifterrOrganizationName";
  private userNameStorageLocation: string = "ShifterrUserName";

  constructor() { }

  // Token handlers

  storeToken(token:string): void{
    localStorage.setItem(this.tokenStorageLocation, token);
  }

  hasToken(): boolean{
    return localStorage.getItem(this.tokenStorageLocation) != null;
  }

  deleteToken(): void{
    localStorage.removeItem(this.tokenStorageLocation);
  }

  // Organization Name Handlers

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

  // Username Handlers

  storeUserName(token:string): void{
    localStorage.setItem(this.userNameStorageLocation, token);
  }

  hasUserName(): boolean{
    return localStorage.getItem(this.userNameStorageLocation) != null;
  }

  getUserName(): string | null{
    return localStorage.getItem(this.userNameStorageLocation);
  }

  deleteUserName(): void{
    localStorage.removeItem(this.userNameStorageLocation);
  }

  // Token, Organization Name, UserName Handlers

  storeTokenOrganizationNameUserName(token: string, organizationName: string, userName: string){
    this.storeToken(token);
    this.storeOrganizationName(organizationName);
    this.storeUserName(userName);
  }

  hasTokenOrganizationNameUserName(): boolean{
    return this.hasToken() && this.hasOrganizationName() && this.hasUserName();
  }

  deleteTokenOrganizationNameUserName(): void{
    this.deleteToken();
    this.deleteOrganizationName();
    this.deleteUserName();
  }
}
