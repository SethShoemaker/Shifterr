import { TestBed } from '@angular/core/testing';

import { RequestConfirmationService } from './request-confirmation.service';

describe('RequestConfirmationService', () => {
  let service: RequestConfirmationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RequestConfirmationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
