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
import { MenuComponent } from './menu/menu.component';
import { EqualValidator } from './_helpers/equal-validator.directive';
import { GamePlayComponent } from './game-play/game-play.component';
import { PlayerDetailsComponent } from './game-play/player-details/player-details.component';
import { HistoryGamesComponent } from './history-games/history-games.component';
import { RoundDetailsComponent } from './history-games/round-details/round-details.component';

@NgModule({
  declarations: [
    AppComponent,
    AccountComponent,
    LoginComponent,
    RegisterComponent,
    MenuComponent,
    GamePlayComponent,
    PlayerDetailsComponent,
    HistoryGamesComponent,
    RoundDetailsComponent,
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
