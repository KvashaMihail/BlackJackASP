import { Component } from '@angular/core';
import { Validators, FormBuilder } from '@angular/forms';
import { LoginAccountView } from 'src/app/viewModels/account/LoginAccountView';
import { AccountService } from 'src/app/services/account';

@Component({
  selector: 'app-account-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  constructor(private accountService: AccountService) {
  }
  public model: LoginAccountView = new LoginAccountView();

  login(): void {
    this.accountService.login(this.model); //.subscribe(
    //   data => console.log("data"),
    //   error => console.log("error")
    // );
  }
}
