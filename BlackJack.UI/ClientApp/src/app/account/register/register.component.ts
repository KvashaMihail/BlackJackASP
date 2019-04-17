import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { RegisterAccountView } from 'src/app/viewModels/account/RegisterAccountView';
import { AccountService } from 'src/app/services/account';

@Component({
  selector: 'app-account-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})

export class RegisterComponent {
  
  constructor(private accountService: AccountService) {
  }
  public model: RegisterAccountView = new RegisterAccountView();

  register(): void {
    this.accountService.register(this.model).subscribe(
      data => console.log(data),
      error => console.log(error)
    );
  }
}
