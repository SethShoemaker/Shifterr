import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class TableHeaderSearchComponent implements OnInit {

  @Input() tableTopic: string = null!;

  constructor() { }

  ngOnInit(): void {
  }

}
