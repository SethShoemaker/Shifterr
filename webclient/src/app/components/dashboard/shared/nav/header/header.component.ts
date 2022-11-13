import { Component, Input, OnInit } from '@angular/core';
import { StorageService } from 'src/app/services/auth/storage/storage.service';

@Component({
  selector: 'app-dashboard-nav-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  @Input() organizationName: string | null =  null;
  @Input() userName: string | null = null;

  dropdownActivated: boolean = false;

  constructor() {}

  ngOnInit(): void {
  }

  toggleDropdown(): void{
    this.dropdownActivated = !this.dropdownActivated;
  }
}
