import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthHandleConfirmationComponent } from './handle-confirmation.component';

describe('AuthHandleConfirmationComponent', () => {
  let component: AuthHandleConfirmationComponent;
  let fixture: ComponentFixture<AuthHandleConfirmationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuthHandleConfirmationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AuthHandleConfirmationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
