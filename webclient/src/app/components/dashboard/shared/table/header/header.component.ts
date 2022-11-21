import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-table-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class TableHeaderComponent implements OnInit {

  @Output() refreshEmitter: EventEmitter<any> = new EventEmitter<any>();
  @Output() addEmitter: EventEmitter<any> = new EventEmitter<any>();
  @Output() searchEmitter: EventEmitter<string> = new EventEmitter<string>();

  @Input() createVerb: string = "Create";
  @Input() tableTopic: string = "Table";
  @Input() canCreate: boolean = null!;

  constructor() { }

  ngOnInit(): void {
  }

  onRefreshClick(){
    this.refreshEmitter.emit();
  }

  onAddClick(){
    this.addEmitter.emit();
  }

  onSearchQueryChange(query: string){
    this.searchEmitter.emit(query);
  }
}
