import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  //{ path: '', redirectTo: 'account', pathMatch: 'full' },
  //{
  //  path: '', children:
  //    [
  //      { path: 'account', loadChildren: "./account/account.module#AccountModule" }
  //      //{ path: 'menu', loadChildren: "./menu/menu.module#MenuModule" },
  //      //{ path: 'game', loadChildren: "./game/game.module#GameModule" }
  //    ]
  //},
  //{ path: '**', redirectTo: '/404', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
