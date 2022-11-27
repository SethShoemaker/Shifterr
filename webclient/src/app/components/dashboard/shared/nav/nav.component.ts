import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LogoutService } from 'src/app/services/auth/logout/logout.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {

  @Input() organizationName: string | null = null!;
  @Input() organizationRole: string | null = null!;
  @Input() userName: string | null = null!;
  @Input() nickname: string | null = null!;

  sidebarActivated: boolean = false;

  constructor(
    private logoutService: LogoutService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.router.events.subscribe(
      // Success
      () => {
        this.sidebarActivated = false;
      }
    )
  }

  toggleSidebar(sidebarActivated: boolean){
    this.sidebarActivated = sidebarActivated;
  }

  onLogout(){
    this.logoutService.logout();
  }
}
