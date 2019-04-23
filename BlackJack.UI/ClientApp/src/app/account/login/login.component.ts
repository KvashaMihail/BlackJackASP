import { Component } from '@angular/core';
import { AccountView } from 'src/app/_viewModels/account/AccountView';
import { AccountService } from 'src/app/_services/account';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-account-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  public errors: string[];

  constructor(private accountService: AccountService, private router: Router) {
  }
  public model: AccountView = new AccountView();

  login(): void {
    this.errors = [];
    this.accountService.login(this.model).subscribe(
      () => this.router.navigateByUrl("/game"),
      (error: HttpErrorResponse) => this.errors = error.error
    );
  }
}
