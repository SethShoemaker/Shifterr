import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-confirmation',
  templateUrl: './confirmation.component.html',
  styleUrls: ['./confirmation.component.scss']
})
export class ConfirmationComponent implements OnInit {

  @Output() cancelEmitter: EventEmitter<any> = new EventEmitter<any>;
  @Output() confirmEmitter: EventEmitter<any> = new EventEmitter<any>;

  @Input() deleteSubject: string = null!;
  @Input() overlayIsNeeded: boolean = true;

  constructor() { }

  ngOnInit(): void {
  }

  onDeleteButtonClick(){
    this.confirmEmitter.emit();
  }

  onCancelButtonClick(){
    this.cancelEmitter.emit();
  }
}
