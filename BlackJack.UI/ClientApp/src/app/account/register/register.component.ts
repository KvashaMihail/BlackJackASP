import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { RegisterAccountView } from 'src/app/viewModels/account/RegisterAccountView';
import { AccountService } from 'src/app/services/account';
import { Router } from '@angular/router';

@Component({
  selector: 'app-account-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})

export class RegisterComponent {
  
  constructor(private accountService: AccountService, private router: Router) {
  }
  public model: RegisterAccountView = new RegisterAccountView();

  register(): void {
    this.accountService.register(this.model).subscribe(
      data => this.router.navigateByUrl("/game"),
      error => console.log(error)
    );
  }
}
