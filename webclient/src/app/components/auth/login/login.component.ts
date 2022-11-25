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
      res => {
        this.storageService.storeAllAuthDetails(res.token, res.organizationName, res.organizationRole, res.userName, res.nickname);
        this.router.navigateByUrl("dashboard");
      },
      // Fail
      res => {
        if(res.status == 401){
          if(res.error.responseText == 'User Not Found') this.errorMessage = "Error: User Not Found";
          if(res.error.responseText == 'Bad Credentials') this.errorMessage = "Error: Bad Credentials";
          if(res.error.responseText == 'User Not Confirmed') this.router.navigateByUrl("login/confirm");
        }
        this.loginRequestBody.Password = "";
      }
    ); 
  }
}