import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-dashboard-nav-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  @Input() organizationRole: string | null = null;
  @Input() nickname: string | null = null;
  @Input() userName: string | null = null;
  @Input() sidebarActivated: boolean = false;

  @Output() logoutEmitter: EventEmitter<boolean> = new EventEmitter<boolean>();

  constructor() { }

  ngOnInit(): void {
  }

  onLogout(){
    this.logoutEmitter.emit();
  }
}
