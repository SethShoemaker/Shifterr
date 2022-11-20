import { Injectable } from '@angular/core';
import { StorageService } from '../storage/storage.service';

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  constructor(private storageService: StorageService) {}

  public isManager(): boolean{
    var organizationRole = this.storageService.getOrganizationRole()
    return (organizationRole == "Manager") || (organizationRole == "Administrator");
  }

  public isAdmin(): boolean{
    var organizationRole = this.storageService.getOrganizationRole()
    return (organizationRole == "Administrator");
  }
}
