import { Component } from '@angular/core';
import { Validators, FormBuilder } from '@angular/forms';
import { LoginAccountView } from 'src/app/viewModels/LoginAccountView';

@Component({
  selector: 'app-account-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  public model: LoginAccountView = new LoginAccountView();
}
