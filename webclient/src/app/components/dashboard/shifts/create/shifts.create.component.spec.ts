import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShiftsCreateComponent } from './shifts.create.component';

describe('ShiftsCreateComponent', () => {
  let component: ShiftsCreateComponent;
  let fixture: ComponentFixture<ShiftsCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShiftsCreateComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShiftsCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
