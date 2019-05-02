import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MenuComponent } from './menu.component/menu.component';

const routes: Routes = [
  { path: '', redirectTo: 'menu', pathMatch: "full" },
  {
    path: '', children:
      [
        { path: 'game', loadChildren: "./game/game.module#GameModule" },
        { path: 'account', loadChildren: "./account/account.module#AccountModule" },
        { path: 'history', loadChildren: "./history/history.module#HistoryModule" }
      ]
  },
  {
    path: 'menu', component: MenuComponent
  },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
