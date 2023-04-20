import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CalendarIndexWorkerDto } from 'src/app/responses/dashboard/calendar/index.response';
import { RoleService } from 'src/app/services/auth/role/role.service';
import { ShiftsService } from 'src/app/services/dashboard/shifts/shifts.service';
import { AlertService } from 'src/app/services/shared/alert/alert.service';
import { LoadingService } from 'src/app/services/shared/loading/loading.service';

@Component({
  selector: 'app-calendar-index',
  templateUrl: './calendar.index.component.html',
  styleUrls: ['./calendar.index.component.scss']
})
export class CalendarIndexComponent implements OnInit {

  todaysDateTime: number = null!;
  calendarStartDate: Date = null!;
  dates: Date[] = [];

  workers: CalendarIndexWorkerDto[] = [];

  canEdit: boolean = this.roleService.isManager();

  shiftIsSelected: boolean = false;
  selectedShiftId: number = null!;

  constructor(
    private shiftsService: ShiftsService,
    private loadingService: LoadingService,
    private alertService: AlertService,
    private router: Router,
    private roleService: RoleService
  ){}

  ngOnInit(): void {
    var today: Date = new Date();
    today.setHours(0);
    today.setMinutes(0);
    today.setSeconds(0, 0);

    this.todaysDateTime = today.getTime();

    this.calendarStartDate = today;
    // Set to most recent sunday
    this.calendarStartDate.setDate(this.calendarStartDate.getDate() - this.calendarStartDate.getDay());

    this.setDateArray();
    this.getShifts();
  }

  setDateArray(){
    for (let i = 0; i < 7; i++) {
      var weekDay: Date = structuredClone(this.calendarStartDate);
      weekDay.setDate(weekDay.getDate() + i);
      this.dates[i] = weekDay;
    }
  }

  getShifts(){
    this.loadingService.startLoading();
    var from: string = this.dates[0].toISOString();
    var toDate: Date = structuredClone(this.dates[this.dates.length - 1]);
    toDate.setHours(23);
    toDate.setMinutes(59);
    var to: string = toDate.toISOString();
    this.shiftsService.getCalendarShifts(from, to).subscribe(
      // Success
      res => {
        this.workers = res.workers;
      },
      err => {
        this.alertService.alertErrorFromStatus(err.status);
      }
    );
    this.loadingService.finishedLoading();
  }

  displayShiftInfo(shiftId: number){
    this.selectedShiftId = shiftId;
    this.shiftIsSelected = true;
  }

  removeShiftInfo(){
    this.selectedShiftId = null!;
    this.shiftIsSelected = false;
    this.getShifts();
  }

  getShortDate(date: Date): string{
    return formatDate(date, 'M/d/yyyy', 'en');
  }

  nextWeek(){
    this.calendarStartDate.setDate(this.calendarStartDate.getDate() + 7);
    this.setDateArray();
    this.getShifts();
  }

  previousWeek(){
    this.calendarStartDate.setDate(this.calendarStartDate.getDate() - 7);
    this.setDateArray();
    this.getShifts();
  }

  onCreateClick(){
    this.router.navigateByUrl("dashboard/shifts/create");
  }
}
