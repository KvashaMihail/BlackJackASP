import { Component, Output, EventEmitter } from '@angular/core';
import { Validators, FormBuilder } from '@angular/forms';
import { LoginAccountView } from 'src/app/viewModels/account/LoginAccountView';
import { AccountService } from 'src/app/services/account';
import { Router } from '@angular/router';

@Component({
  selector: 'app-account-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  constructor(private accountService: AccountService, private router: Router) {
  }
  public model: LoginAccountView = new LoginAccountView();

  @Output() onSigned = new EventEmitter();

  login(): void {
    this.accountService.login(this.model).subscribe(
       data => this.router.navigateByUrl("/game"),
       error => console.log("error")
     );
  }
}
