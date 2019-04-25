import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountComponent } from './components/account-component/account.component';
import { LoginComponent } from './components/account-component/login/login.component';
import { RegisterComponent } from './components/account-component/register/register.component';
import { MenuComponent } from './components/menu/menu.component';
import { GamePlayComponent } from './components/game-play/game-play.component';
import { HistoryGamesComponent } from './components/history-games/history-games.component';



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
