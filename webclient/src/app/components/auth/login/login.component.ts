import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginRequestBody } from 'src/app/requests/login.request';
import { LoginService } from 'src/app/services/auth/login/login.service';
import { TokenService } from 'src/app/services/auth/token/token.service';

@Component({
  selector: 'app-login',
  providers: [LoginService],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public loginRequestBody = new LoginRequestBody();

  public errorMessage: string = null!;

  constructor(
    private loginService: LoginService,
    private tokenService: TokenService,
    private router: Router
  ){}

  ngOnInit(): void {}

  onSubmit(): void{
    this.loginService.attemptLogin(this.loginRequestBody).subscribe(
      // Success
      response => {
        this.tokenService.storeToken(response.token);
        this.router.navigateByUrl("dashboard");
      },
      // Fail
      response => {
        this.errorMessage = response.error;
        this.loginRequestBody.Password = "";
      }
    ); 
  }
}