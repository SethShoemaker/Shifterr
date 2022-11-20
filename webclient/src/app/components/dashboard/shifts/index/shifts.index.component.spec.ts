import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShiftsIndexComponent } from './shifts.index.component';

describe('ShiftsComponent', () => {
  let component: ShiftsIndexComponent;
  let fixture: ComponentFixture<ShiftsIndexComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShiftsIndexComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShiftsIndexComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
