import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthHandleConfirmationComponent } from './components/auth/handle-confirmation/handle-confirmation/handle-confirmation.component';

import { AuthLoginComponent } from './components/auth/login/login.component';
import { AuthRequestConfirmationComponent } from './components/auth/request-confirmation/request-confirmation.component';
import { CalendarComponent } from './components/dashboard/calendar/calendar.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PositionsComponent } from './components/dashboard/positions/positions.component';
import { ShiftsIndexComponent } from './components/dashboard/shifts/index/shifts.index.component';
import { WorkersComponent } from './components/dashboard/workers/workers.component';
import { AuthGuard } from './guards/auth/auth.guard';


const routes: Routes = [
  {
    path : "login",
    title: "Login",
    component : AuthLoginComponent
  },
  {
    path: "login/confirm", 
    title: "Confirm",
    component: AuthRequestConfirmationComponent
  },
  {
    path: "login/confirm/handle", 
    title: "Confirm",
    component: AuthHandleConfirmationComponent
  },
  {
    path : "dashboard",
    canActivate: [AuthGuard],
    component: DashboardComponent,
    children: [
      {
        path: "shifts",
        canActivate: [AuthGuard],
        title: "Shifts",
        component: ShiftsIndexComponent
      },
      {
        path: "calendar",
        canActivate: [AuthGuard],
        title: "Calendar",
        component: CalendarComponent
      },
      {
        path: "positions",
        canActivate: [AuthGuard],
        title: "Positions",
        component: PositionsComponent
      },
      {
        path: "workers",
        canActivate: [AuthGuard],
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
