import { Component } from '@angular/core';
import { AccountView } from 'src/app/_viewModels/account/AccountView';
import { AccountService } from 'src/app/_services/account';
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
      () => this.router.navigateByUrl("/game"),
      (error: HttpErrorResponse) => {
        this.errors = error.error;
        console.log(this.errors);
      } 
    );
  }
}
