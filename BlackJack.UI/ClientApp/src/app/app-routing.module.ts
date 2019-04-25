import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountComponent } from './account/account.component';
import { LoginComponent } from './account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import { MenuComponent } from './menu/menu.component';
import { GamePlayComponent } from './game-play/game-play.component';
import { HistoryGamesComponent } from './history-games/history-games.component';



const routes: Routes = [
  { path: '', redirectTo: 'game', pathMatch: 'full' },
  {
    path: 'account', component: AccountComponent, children: [
      { path: '', redirectTo: 'login', pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent }
    ]
  },
  {
    path: 'game', children: [
      { path: '', redirectTo: 'menu', pathMatch: 'full' },
      { path: 'menu', component: MenuComponent},
      { path: 'game-play', component: GamePlayComponent},
    ]
  },
  { path: 'history', component: HistoryGamesComponent},
  { path: '**', redirectTo: '/404', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
