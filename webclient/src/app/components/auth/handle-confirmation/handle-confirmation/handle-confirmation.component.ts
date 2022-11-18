import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmationService } from 'src/app/services/auth/confirmation/confirmation.service';

@Component({
  selector: 'app-auth-handle-confirmation',
  templateUrl: './handle-confirmation.component.html',
  styleUrls: ['./handle-confirmation.component.scss']
})
export class AuthHandleConfirmationComponent implements OnInit {

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private confirmationService: ConfirmationService
  ) { }

  ngOnInit(): void {
    var confirmationKey = this.activatedRoute.snapshot.queryParamMap.get("ConfirmationKey");
    if(confirmationKey == null){
      this.router.navigateByUrl('/');
      return;
    }

    var userId = this.activatedRoute.snapshot.queryParamMap.get("UserId");
    if(userId == null){
      this.router.navigateByUrl('/');
      return;
    }

    this.confirmationService.handleConfirmation(confirmationKey, userId).subscribe(
      // Success
      res => {
        this.router.navigateByUrl('login');
      },
      // Error
      res => {
        this.router.navigateByUrl('/');
      }
    )
  }

}
