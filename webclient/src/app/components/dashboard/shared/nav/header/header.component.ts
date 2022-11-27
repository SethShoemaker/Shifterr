import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { LogoutService } from 'src/app/services/auth/logout/logout.service';

@Component({
  selector: 'app-dashboard-nav-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  @Input() organizationName: string | null =  null;
  @Input() userName: string | null = null;

  sidebarActivated: boolean = false;
  @Output() sidebarEmitter: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Output() logoutEmitter: EventEmitter<boolean> =  new EventEmitter<boolean>();

  dropdownActivated: boolean = false;

  constructor() {}

  ngOnInit(): void {
  }

  toggleDropdown(): void{
    this.dropdownActivated = !this.dropdownActivated;
  }

  onLogout(): void{
    this.logoutEmitter.emit();
  }

  toggleSidebar(){
    this.sidebarActivated = !this.sidebarActivated;
    this.sidebarEmitter.emit(this.sidebarActivated);
  }
}
