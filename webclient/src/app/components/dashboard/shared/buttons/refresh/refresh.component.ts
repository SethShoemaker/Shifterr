import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-refresh',
  templateUrl: './refresh.component.html',
  styleUrls: ['./refresh.component.scss']
})
export class RefreshComponent implements OnInit {

  @Input() hasMb: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

}
