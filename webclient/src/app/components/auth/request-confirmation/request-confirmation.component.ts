import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RequestConfirmationRequestBody } from 'src/app/requests/request-confirmation.request';
import { ConfirmationService } from 'src/app/services/auth/confirmation/confirmation.service';

@Component({
  selector: 'app-auth-request-confirmation',
  templateUrl: './request-confirmation.component.html',
  styleUrls: ['./request-confirmation.component.scss']
})
export class AuthRequestConfirmationComponent implements OnInit {

  public message: string = null!;

  public request: RequestConfirmationRequestBody = new RequestConfirmationRequestBody();

  constructor(
    private confirmationService: ConfirmationService,
    private router: Router
    ) { }

  ngOnInit(): void {
  }

  onSubmit(){
    this.confirmationService.requestConfirmation(this.request).subscribe(
      // Success 
      res =>{
        this.message = "Confirmation Sent";
      },
      // Error
      res => {
        if(res.status == 401){
          if(res.error == "User Not Found") this.message = "User Not Found";
          if(res.error == "Bad Credentials") this.message = "Bad Credentials";
          if(res.error == "User Already Confirmed") this.router.navigateByUrl("login");
        }
        this.request.Password = "";
      }
    )
  }
}
