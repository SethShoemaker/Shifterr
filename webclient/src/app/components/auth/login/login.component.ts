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
export class LoginComponent implements OnInit {

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
        this.errorMessage = `Error: ${response.error}`;
        this.loginRequestBody.Password = "";
      }
    ); 
  }
}