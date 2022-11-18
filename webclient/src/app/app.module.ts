import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthLoginComponent } from './components/auth/login/login.component';
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
import { TableHeaderComponent } from './components/dashboard/shared/table/header/header.component';
import { RefreshComponent } from './components/dashboard/shared/buttons/refresh/refresh.component';
import { TableHeaderSearchComponent } from './components/dashboard/shared/table/header/search/search.component';
import { TableHeaderCreateComponent } from './components/dashboard/shared/table/header/create/create.component';
import { ConfirmationComponent } from './components/dashboard/shared/confirmation/confirmation.component';
import { DeleteComponent } from './components/dashboard/shared/buttons/delete/delete.component';
import { CancelComponent } from './components/dashboard/shared/buttons/cancel/cancel.component';
import { AlertComponent } from './components/dashboard/shared/alert/alert.component';
import { ScreenOverlayComponent } from './components/dashboard/shared/screen-overlay/screen-overlay.component';
import { AuthRequestConfirmationComponent } from './components/auth/request-confirmation/request-confirmation.component';
import { AuthBackdropComponent } from './components/auth/shared/backdrop/backdrop.component';
import { AuthHandleConfirmationComponent } from './components/auth/handle-confirmation/handle-confirmation/handle-confirmation.component';

@NgModule({
  declarations: [
    AppComponent,
    AuthLoginComponent,
    ShiftsComponent,
    CalendarComponent,
    WorkersComponent,
    PositionsComponent,
    NavComponent,
    DashboardComponent,
    HeaderComponent,
    SidebarComponent,
    RefreshComponent,
    TableHeaderSearchComponent,
    TableHeaderCreateComponent,
    TableHeaderComponent,
    ConfirmationComponent,
    DeleteComponent,
    CancelComponent,
    AlertComponent,
    ScreenOverlayComponent,
    AuthRequestConfirmationComponent,
    AuthBackdropComponent,
    AuthHandleConfirmationComponent
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
