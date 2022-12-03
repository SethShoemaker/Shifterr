import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthLoginComponent } from './components/auth/login/login.component';
import { ShiftsIndexComponent } from './components/dashboard/shifts/index/shifts.index.component';
import { PositionsIndexComponent } from './components/dashboard/positions/index/positions.index.component';
import { NavComponent } from './components/dashboard/shared/nav/nav.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { LoginService } from './services/auth/login/login.service';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { HeaderComponent } from './components/dashboard/shared/nav/header/header.component';
import { SidebarComponent } from './components/dashboard/shared/nav/sidebar/sidebar.component';
import { ApiService } from './services/shared/api/api.service';
import { AlertService } from './services/shared/alert/alert.service';
import { ShiftsService } from './services/dashboard/shifts/shifts.service';
import { AuthInterceptor } from 'src/app/interceptors/auth/auth.interceptor';
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
import { PositionsCreateComponent } from './components/dashboard/positions/create/positions.create.component';
import { WorkersIndexComponent } from './components/dashboard/workers/index/workers.index.component';
import { WorkersCreateComponent } from './components/dashboard/workers/create/workers.create.component';
import { WorkersEditComponent } from './components/dashboard/workers/edit/workers.edit.component';
import { PositionsEditComponent } from './components/dashboard/positions/edit/positions.edit.component';
import { LoadingComponent } from './components/dashboard/shared/loading/loading.component';
import { CalendarIndexComponent } from './components/dashboard/calendar/index/calendar.index.component';
import { ShiftsCreateComponent } from './components/dashboard/shifts/create/shifts.create.component';
import { ShiftsShowComponent } from './components/dashboard/shifts/show/shifts.show.component';

@NgModule({
  declarations: [
    AppComponent,
    AuthLoginComponent,
    ShiftsIndexComponent,
    PositionsIndexComponent,
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
    AuthHandleConfirmationComponent,
    PositionsCreateComponent,
    WorkersIndexComponent,
    WorkersCreateComponent,
    WorkersEditComponent,
    PositionsEditComponent,
    LoadingComponent,
    CalendarIndexComponent,
    ShiftsCreateComponent,
    ShiftsShowComponent
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
    ShiftsService,
    AlertService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
