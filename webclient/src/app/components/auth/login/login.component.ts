import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginRequestBody } from 'src/app/requests/login.request';
import { LoginService } from 'src/app/services/auth/login/login.service';
import { StorageService } from 'src/app/services/auth/storage/storage.service';

@Component({
  selector: 'app-login',
  providers: [LoginService],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class AuthLoginComponent implements OnInit {

  public loginRequestBody = new LoginRequestBody();

  public errorMessage: string = null!;

  constructor(
    private loginService: LoginService,
    private storageService: StorageService,
    private router: Router
  ){}

  ngOnInit(): void {}

  onSubmit(): void{
    this.loginService.attemptLogin(this.loginRequestBody).subscribe(
      // Success
      response => {
        this.storageService.storeAllAuthDetails(response.token, response.organizationName, response.organizationRole, response.userName);
        this.router.navigateByUrl("dashboard");
      },
      // Fail
      response => {
        if(response.status == 401){
          if(response.error == 'User Not Found') this.errorMessage = "Error: User Not Found";
          if(response.error == 'Bad Credentials') this.errorMessage = "Error: Bad Credentials";
          if(response.error == 'User Not Confirmed') this.router.navigateByUrl("confirm");
        }
        this.loginRequestBody.Password = "";
      }
    ); 
  }
}