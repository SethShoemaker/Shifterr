import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class TableHeaderCreateComponent implements OnInit {

  @Input() createVerb: string = null!;
  @Input() tableTopic: string = null!;

  constructor() { }

  ngOnInit(): void {
  }

}
