import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PositionsIndexComponent } from './positions.index.component';

describe('PositionsComponent', () => {
  let component: PositionsIndexComponent;
  let fixture: ComponentFixture<PositionsIndexComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PositionsIndexComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PositionsIndexComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
