import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkersIndexComponent } from './workers.index.component';

describe('WorkersIndexComponent', () => {
  let component: WorkersIndexComponent;
  let fixture: ComponentFixture<WorkersIndexComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WorkersIndexComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WorkersIndexComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
