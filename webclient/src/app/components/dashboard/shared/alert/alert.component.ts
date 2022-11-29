import { Component, OnInit } from '@angular/core';
import { Alert, AlertService } from 'src/app/services/shared/alert/alert.service';

@Component({
  selector: 'app-alert',
  templateUrl: './alert.component.html',
  styleUrls: ['./alert.component.scss']
})
export class AlertComponent implements OnInit {

  alerts: Alert[] = [];

  constructor(private alertService: AlertService) { }

  ngOnInit(): void {
    this.alertService.getAlerts().subscribe(
      // Success
      alerts => {
        this.alerts = alerts
      }
    )
  }
}
