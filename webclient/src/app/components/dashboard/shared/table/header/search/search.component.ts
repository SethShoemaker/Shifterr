import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-table-header-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class TableHeaderSearchComponent implements OnInit {

  @Output() searchEmitter: EventEmitter<string> = new EventEmitter<string>();

  @Input() tableTopic: string = null!;

  searchQuery = new FormControl('');

  constructor() { }

  ngOnInit(): void {
    this.searchQuery.valueChanges.subscribe(
      // Success
      val => {
        this.searchEmitter.emit(val?.toString());
      }
    )
  }
}
