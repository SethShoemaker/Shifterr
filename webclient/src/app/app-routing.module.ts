import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthHandleConfirmationComponent } from './components/auth/handle-confirmation/handle-confirmation/handle-confirmation.component';

import { AuthLoginComponent } from './components/auth/login/login.component';
import { AuthRequestConfirmationComponent } from './components/auth/request-confirmation/request-confirmation.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PositionsCreateComponent } from './components/dashboard/positions/create/positions.create.component';
import { PositionsEditComponent } from './components/dashboard/positions/edit/positions.edit.component';
import { PositionsIndexComponent } from './components/dashboard/positions/index/positions.index.component';
import { ShiftsIndexComponent } from './components/dashboard/shifts/index/shifts.index.component';
import { WorkersCreateComponent } from './components/dashboard/workers/create/workers.create.component';
import { WorkersEditComponent } from './components/dashboard/workers/edit/workers.edit.component';
import { WorkersIndexComponent } from './components/dashboard/workers/index/workers.index.component';
import { CalendarIndexComponent } from './components/dashboard/calendar/index/calendar.index.component';
import { AuthGuard } from './guards/auth/auth.guard';
import { AdminGuard } from './guards/auth/role/admin/admin.guard';
import { ManagerGuard } from './guards/auth/role/manager/manager.guard';
import { ShiftsCreateComponent } from './components/dashboard/shifts/create/shifts.create.component';


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
        component: ShiftsIndexComponent,
        data: {
          "header": "Your Shifts"
        }
      },
      {
        path: "shifts/create",
        canActivate: [ManagerGuard],
        title: "Create Shift",
        component: ShiftsCreateComponent,
        data: {
          "header": "Create Shift"
        }
      },
      {
        path: "calendar",
        canActivate: [AuthGuard],
        title: "Calendar",
        component: CalendarIndexComponent,
        data: {
          "header": "Calendar"
        }
      },
      {
        path: "positions",
        canActivate: [AuthGuard],
        title: "Positions",
        component: PositionsIndexComponent,
        data: {
          "header": "Positions"
        }
      },
      {
        path: "positions/create",
        canActivate: [AuthGuard, ManagerGuard],
        title: "Create Positions",
        component: PositionsCreateComponent,
        data: {
          "header": "Create Position"
        }
      },
      {
        path: "positions/edit/:id",
        canActivate: [AuthGuard, ManagerGuard],
        title: "Edit Position",
        component: PositionsEditComponent,
        data: {
          "header": "Edit Position"
        }
      },
      {
        path: "workers",
        canActivate: [AuthGuard],
        title: "Workers",
        component: WorkersIndexComponent,
        data: {
          "header": "Workers"
        }
      },
      {
        path: "workers/register",
        canActivate: [AuthGuard, AdminGuard],
        title: "Register Worker",
        component: WorkersCreateComponent,
        data: {
          "header": "Register Worker"
        }
      },
      {
        path: "workers/edit/:id",
        canActivate: [AuthGuard, AdminGuard],
        title: "Edit Worker",
        component: WorkersEditComponent,
        data: {
          "header": "Edit Worker"
        }
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
