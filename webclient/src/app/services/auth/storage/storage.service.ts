import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  private tokenStorageLocation: string = "ShifterrAuthToken";
  private organizationNameStorageLocation: string = "ShifterrOrganizationName";
  private organizationRoleStorageLocation: string = "ShifterrOrganizationRole";
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

    // Organization Name Handlers

    storeOrganizationRole(token:string): void{
      localStorage.setItem(this.organizationRoleStorageLocation, token);
    }
  
    hasOrganizationRole(): boolean{
      return localStorage.getItem(this.organizationRoleStorageLocation) != null;
    }
  
    getOrganizationRole(): string | null{
      return localStorage.getItem(this.organizationRoleStorageLocation);
    }
  
    deleteOrganizationRole(): void{
      localStorage.removeItem(this.organizationRoleStorageLocation);
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

  // Token, Organization Name, Organization Role, UserName Handlers

  storeAllAuthDetails(token: string, organizationName: string, organizationRole: string, userName: string){
    this.storeToken(token);
    this.storeOrganizationName(organizationName);
    this.storeOrganizationRole(organizationRole);
    this.storeUserName(userName);
  }

  hasAllAuthDetails(): boolean{
    return this.hasToken() && 
    this.hasOrganizationName() && 
    this.hasUserName() &&
    this.hasOrganizationRole();
  }

  deleteTokenOrganizationNameUserName(): void{
    this.deleteToken();
    this.deleteOrganizationName();
    this.deleteUserName();
  }
}
