import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from './app-routing.module.old';
import { AppComponent } from './app.component';
import { AccountComponent } from './components/account-component/account.component';
import { LoginComponent } from './components/account-component/login/login.component';
import { RegisterComponent } from './components/account-component/register/register.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpTokenInterceptor } from './_helpers/token.interceptor';
import { HttpErrorInterceptor } from './_helpers/error.interceptor';
import { MenuComponent } from './components/menu/menu.component';
import { EqualValidator } from './_helpers/equal-validator.directive';
import { GamePlayComponent } from './components/game-play/game-play.component';
import { PlayerDetailsComponent } from './components/game-play/player-details/player-details.component';
import { HistoryGamesComponent } from './components/history-games/history-games.component';
import { RoundDetailsComponent } from './components/history-games/round-details/round-details.component';

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
