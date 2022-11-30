import { Component, OnInit } from '@angular/core';
import { LoadingService } from 'src/app/services/shared/loading/loading.service';

@Component({
  selector: 'app-loading',
  templateUrl: './loading.component.html',
  styleUrls: ['./loading.component.scss']
})
export class LoadingComponent implements OnInit {

  isLoading: boolean = true;

  constructor(private loadingService: LoadingService) { }

  ngOnInit(): void {
    this.loadingService.isLoadingEmitter.subscribe(
      // Success
      isLoading => {
        this.isLoading = isLoading;
      }
    )
  }

}
