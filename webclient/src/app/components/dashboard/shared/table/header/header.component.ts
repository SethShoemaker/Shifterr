import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-table-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class TableHeaderComponent implements OnInit {

  @Output() refreshEmitter: EventEmitter<any> = new EventEmitter<any>;
  @Output() addEmitter: EventEmitter<any> = new EventEmitter<any>;

  @Input() createVerb: string = "Create";
  @Input() tableTopic: string = "Table";

  constructor() { }

  ngOnInit(): void {
  }

  onRefreshClick(){
    this.refreshEmitter.emit();
  }

  onAddClick(){
    this.addEmitter.emit();
  }
}
