import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard-nav-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  @Input() organizationRole: string | null = null;
  @Input() userName: string | null = null;

  constructor() { }

  ngOnInit(): void {
  }

}
