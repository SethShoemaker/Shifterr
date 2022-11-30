import { EventEmitter, Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {

  isLoadingEmitter: EventEmitter<boolean> = new EventEmitter<boolean>();

  constructor(private router: Router) {
    this.router.events.subscribe(
      // Success
      () => {
        this.startLoading();
      }
    )
  }

  finishedLoading(){
    this.isLoadingEmitter.emit(false);
  }

  startLoading(){
    this.isLoadingEmitter.emit(true);
  }
}
