import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { CalendarComponent } from './components/dashboard/calendar/calendar.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PositionsComponent } from './components/dashboard/positions/positions.component';
import { ShiftsComponent } from './components/dashboard/shifts/shifts.component';
import { WorkersComponent } from './components/dashboard/workers/workers.component';
import { AuthGuard } from './guards/auth/auth.guard';


const routes: Routes = [
  {
    path : "register",
    title: "register",
    component : RegisterComponent
  },
  {
    path : "login",
    title: "login",
    component : LoginComponent
  },
  {
    path : "dashboard",
    canActivate: [AuthGuard],
    component: DashboardComponent,
    children: [
      {
        path: "shifts",
        title: "Shifts",
        component: ShiftsComponent
      },
      {
        path: "calendar",
        title: "Calendar",
        component: CalendarComponent
      },
      {
        path: "positions",
        title: "Positions",
        component: PositionsComponent
      },
      {
        path: "workers",
        title: "Workers",
        component: WorkersComponent
      },
      {
        path : "",
        redirectTo: "shifts", 
        pathMatch: 'full'
      },
    ]
  },
  {
    path : "",
    redirectTo: "dashboard/shifts", 
    pathMatch: 'full'
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
