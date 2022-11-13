import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {

  @Input() organizationName: string | null = null!;
  @Input() userName: string | null = null!;

  constructor() { }

  ngOnInit(): void {
  }

}
