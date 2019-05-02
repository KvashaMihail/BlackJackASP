import { Component } from '@angular/core';
import { AccountView } from 'src/app/shared/_viewModels/account/account.view';
import { AccountService } from 'src/app/shared/_services/account.service';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-account-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  public model: AccountView = new AccountView();
  public confirmPassword: string;
  public errors: string[];

  constructor(private accountService: AccountService, private router: Router) {
  }

  register(): void {
    this.errors = [];
    this.accountService.register(this.model).subscribe(
      () => this.router.navigateByUrl("/menu"),
      (error: HttpErrorResponse) => {
        this.errors = error.error;
        console.log(this.errors);
      } 
    );
  }
}
