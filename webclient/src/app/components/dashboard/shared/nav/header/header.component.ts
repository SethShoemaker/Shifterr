import { Component, Input, OnInit } from '@angular/core';
import { LogoutService } from 'src/app/services/auth/logout/logout.service';

@Component({
  selector: 'app-dashboard-nav-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  @Input() organizationName: string | null =  null;
  @Input() userName: string | null = null;

  dropdownActivated: boolean = false;

  constructor(private logoutService: LogoutService) {}

  ngOnInit(): void {
  }

  toggleDropdown(): void{
    this.dropdownActivated = !this.dropdownActivated;
  }

  onLogout(): void{
    this.logoutService.logout();
  }
}
