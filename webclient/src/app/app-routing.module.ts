import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { HomeComponent } from './components/dashboard/home/home.component';


const routes: Routes = [
  {
    path : "register",
    component : RegisterComponent
  },
  {
    path : "login",
    component : LoginComponent
  },
  {
    path : "dashboard",
    component : HomeComponent
  },
  {
    path : "",
    redirectTo: "login", 
    pathMatch: 'full'
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
