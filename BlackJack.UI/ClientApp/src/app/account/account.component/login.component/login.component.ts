import { Component } from '@angular/core';
import { AccountView } from 'src/app/shared/_viewModels/account/account.view';
import { AccountService } from 'src/app/shared/_services/account.service';
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
      () => this.router.navigateByUrl("/menu"),
      (error: HttpErrorResponse) => this.errors = error.error
    );
  }
}
