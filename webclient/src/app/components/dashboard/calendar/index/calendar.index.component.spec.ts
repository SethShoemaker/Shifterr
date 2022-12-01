import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CalendarIndexComponent } from './calendar.index.component';

describe('CalendarIndexComponent', () => {
  let component: CalendarIndexComponent;
  let fixture: ComponentFixture<CalendarIndexComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CalendarIndexComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CalendarIndexComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
