import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AlertService {

  alerts: Alert[] = [];

  constructor() {
    setInterval(() => {
      for (let i = 0; i < this.alerts.length; i++) {
        var alertTime: number = this.alerts[i].timeCreatedAt;
        var currentTime: number = new Date().getTime();
        var duration = Math.round(currentTime - alertTime);
        if(duration >= 4000){
          this.alerts.splice(i, 1);
        }
      }
    }, 150);
  }

  getAlerts(): Observable<Alert[]>{
    return of(this.alerts);
  }

  private addAlert(alert: Alert){

    this.alerts.unshift(alert);

    if(this.alerts.length == 5){
      this.alerts.pop();
    }
  }

  alertConnectionError(){
    this.alertError("could not connect to server");
  }

  alertUnauthenticated(){
    this.alertError("you are not logged in");
  }

  alertForbidden(){
    this.alertError("you are not have permission");
  }

  alertGenericError(){
    this.alertError("an error has occurred");
  }

  alertErrorFromStatus(status: number){
    if(status == 0){
      this.alertConnectionError();
      return;
    }
    if(status == 401){
      this.alertUnauthenticated();
      return;
    }
    if(status == 403){
      this.alertForbidden();
      return;
    }
    this.alertGenericError();
  }

  alertError(body: string){
    this.addAlert(new Alert(AlertType.error, "Error: " + body));
  }

  alertSuccess(body: string){
    this.addAlert(new Alert(AlertType.success, "Success: " + body));
  }
}

export class Alert{

  constructor(type: AlertType, body: string){
    this.type = type;
    this.body = body;
    this.timeCreatedAt = new Date().getTime();
  }

  type: AlertType = null!;
  body: string = null!;
  timeCreatedAt: number = null!;
}

export enum AlertType{
  error = "error",
  success = "success",
}
