import { Component, OnInit } from '@angular/core';
import { StorageService } from 'src/app/services/auth/storage/storage.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  organizationName: string | null = this.storageService.getOrganizationName();
  userName: string | null = this.storageService.getUserName();

  constructor(private storageService: StorageService) { }

  ngOnInit(): void {
  }

}
