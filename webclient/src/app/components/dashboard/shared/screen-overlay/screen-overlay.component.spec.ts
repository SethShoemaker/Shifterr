import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ScreenOverlayComponent } from './screen-overlay.component';

describe('ScreenOverlayComponent', () => {
  let component: ScreenOverlayComponent;
  let fixture: ComponentFixture<ScreenOverlayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ScreenOverlayComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ScreenOverlayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
