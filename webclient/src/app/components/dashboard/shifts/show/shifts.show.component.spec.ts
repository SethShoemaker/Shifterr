import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShiftsShowComponent } from './shifts.show.component';

describe('ShiftsShowComponent', () => {
  let component: ShiftsShowComponent;
  let fixture: ComponentFixture<ShiftsShowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShiftsShowComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShiftsShowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
