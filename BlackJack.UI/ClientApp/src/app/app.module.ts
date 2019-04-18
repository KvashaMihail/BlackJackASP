import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AccountComponent } from './account/account.component';
import { LoginComponent } from './account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpTokenInterceptor } from './helpers/token.interceptor';
import { HttpErrorInterceptor } from './helpers/error.interceptor';
import { GameComponent } from './game/game.component';
import { ROUTER_PROVIDERS } from '@angular/router/src/router_module';

@NgModule({
  declarations: [
    AppComponent,
    AccountComponent,
    LoginComponent,
    RegisterComponent,
    GameComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpErrorInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpTokenInterceptor,
      multi: true
      }
      
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
