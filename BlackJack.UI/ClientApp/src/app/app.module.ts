import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AccountComponent } from './account/account.component';
import { LoginComponent } from './account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpTokenInterceptor } from './_helpers/token.interceptor';
import { HttpErrorInterceptor } from './_helpers/error.interceptor';
import { GameComponent } from './game/game.component';
import { MenuComponent } from './game/menu/menu.component';
import { EqualValidator } from './_helpers/equal-validator.directive';
import { GamePlayComponent } from './game/gamePlay/game-play.component';
import { PlayerComponent } from './game/gamePlay/player/player.component';
import { HistoryComponent } from './game/history/history.component';
import { RoundComponent } from './game/history/round/round.component';

@NgModule({
  declarations: [
    AppComponent,
    AccountComponent,
    LoginComponent,
    RegisterComponent,
    GameComponent,
    MenuComponent,
    GamePlayComponent,
    PlayerComponent,
    HistoryComponent,
    RoundComponent,
    EqualValidator
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    HttpClientModule,
    FormsModule,
    NgbModule
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
