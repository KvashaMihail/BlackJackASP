import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AccountRoutingModule } from './account-routing.module';
import { AccountComponent } from './account.component';
import { MenuComponent } from './menu/menu.component';

@NgModule({
  declarations: [
    AccountComponent,
    //MenuComponent
  ],
  imports: [
    BrowserModule,
    //AccountRoutingModule
  ],
  providers: [],
  bootstrap: [AccountComponent]
})
export class AccountModule { }
