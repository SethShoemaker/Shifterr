import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthRequestConfirmationComponent } from './request-confirmation.component';

describe('AuthRequestConfirmationComponent', () => {
  let component: AuthRequestConfirmationComponent;
  let fixture: ComponentFixture<AuthRequestConfirmationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuthRequestConfirmationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AuthRequestConfirmationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
