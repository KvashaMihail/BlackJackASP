import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { RegisterAccountView } from 'src/app/viewModels/RegisterAccountView';

@Component({
  selector: 'app-account-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  public model: RegisterAccountView = new RegisterAccountView();
}
