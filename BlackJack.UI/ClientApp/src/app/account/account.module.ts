import { AccountComponent } from './account.component/account.component';
import { LoginComponent } from './account.component/login.component/login.component';
import { RegisterComponent } from './account.component/register.component/register.component';
import { NgModule } from '@angular/core';
import { EqualValidator } from '../shared/_helpers/equal.validator.directive';
import { CommonModule } from '@angular/common';
import { AccountRoutingModule } from './account.routing.module';
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