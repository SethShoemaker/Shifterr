import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { StorageService } from 'src/app/services/auth/storage/storage.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  title: string | undefined = null!;

  organizationName: string | null = this.storageService.getOrganizationName();
  organizationRole: string | null = this.storageService.getOrganizationRole();
  userName: string | null = this.storageService.getUserName();

  constructor(
    private storageService: StorageService,
    private activatedRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    // Change component title
    this.activatedRoute.url.subscribe(url => {
      var activatedRoutePath = this.activatedRoute.snapshot.firstChild?.routeConfig?.path;
      if (activatedRoutePath == null) return;
      activatedRoutePath = activatedRoutePath[0].toUpperCase() + activatedRoutePath.slice(1);
      this.title = activatedRoutePath;
    });
  }
}
