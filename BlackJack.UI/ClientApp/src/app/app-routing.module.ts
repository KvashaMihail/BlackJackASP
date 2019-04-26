import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MenuComponent } from './components/menu/menu.component';

const routes: Routes = [
  { path: '', redirectTo: 'menu', pathMatch: "full" },
  {
    path: '', children:
      [
        { path: 'game', loadChildren: "./modules/game.module#GameModule" },
        { path: 'account', loadChildren: "./modules/account.module#AccountModule" },
        { path: 'history', loadChildren: "./modules/history.module#HistoryModule" }
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
