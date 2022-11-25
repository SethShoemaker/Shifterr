import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PositionsEditComponent } from './positions.edit.component';

describe('PositionsEditComponent', () => {
  let component: PositionsEditComponent;
  let fixture: ComponentFixture<PositionsEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PositionsEditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PositionsEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
