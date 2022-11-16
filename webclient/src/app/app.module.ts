import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { ShiftsComponent } from './components/dashboard/shifts/shifts.component';
import { CalendarComponent } from './components/dashboard/calendar/calendar.component';
import { WorkersComponent } from './components/dashboard/workers/workers.component';
import { PositionsComponent } from './components/dashboard/positions/positions.component';
import { NavComponent } from './components/dashboard/shared/nav/nav.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { LoginService } from './services/auth/login/login.service';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { HeaderComponent } from './components/dashboard/shared/nav/header/header.component';
import { SidebarComponent } from './components/dashboard/shared/nav/sidebar/sidebar.component';
import { ApiService } from './services/shared/api/api.service';
import { ShiftsService } from './services/dashboard/shifts/shifts.service';
import { AuthInterceptor } from 'src/interceptors/auth/auth.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    ShiftsComponent,
    CalendarComponent,
    WorkersComponent,
    PositionsComponent,
    NavComponent,
    DashboardComponent,
    HeaderComponent,
    SidebarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    AuthInterceptor,
    {

      provide: HTTP_INTERCEPTORS,
      
      useClass: AuthInterceptor,
      
      multi: true
      
    },
    ApiService,
    LoginService,
    ShiftsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
