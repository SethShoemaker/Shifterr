import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkersCreateComponent } from './workers.create.component';

describe('WorkersCreateComponent', () => {
  let component: WorkersCreateComponent;
  let fixture: ComponentFixture<WorkersCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WorkersCreateComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WorkersCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
