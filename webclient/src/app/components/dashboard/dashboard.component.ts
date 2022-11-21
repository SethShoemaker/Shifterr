import { Component, OnInit } from '@angular/core';
import { Router,  ActivationStart, ActivatedRoute } from '@angular/router';
import { StorageService } from 'src/app/services/auth/storage/storage.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  title: string | undefined = "Your Shifts";

  organizationName: string | null = this.storageService.getOrganizationName();
  organizationRole: string | null = this.storageService.getOrganizationRole();
  userName: string | null = this.storageService.getUserName();

  constructor(
    private storageService: StorageService,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    // Change page title
    this.activatedRoute.url.subscribe(() => {
      this.title = this.activatedRoute.snapshot.firstChild?.data['header'];
    })
  }
}
