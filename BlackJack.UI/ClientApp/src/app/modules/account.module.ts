import { AccountComponent } from '../components/account-component/account.component';
import { LoginComponent } from '../components/account-component/login/login.component';
import { RegisterComponent } from '../components/account-component/register/register.component';
import { NgModule } from '@angular/core';
import { EqualValidator } from '../_helpers/equal-validator.directive';
import { CommonModule } from '@angular/common';
import { AccountRoutingModule } from './account-routing.module';
import { FormsModule } from '@angular/forms';

@NgModule({
    declarations: [
        AccountComponent,
        LoginComponent,
        RegisterComponent,
        EqualValidator
      ],
  imports: [
    CommonModule,
    AccountRoutingModule,
    FormsModule
  ]
})
export class AccountModule { }