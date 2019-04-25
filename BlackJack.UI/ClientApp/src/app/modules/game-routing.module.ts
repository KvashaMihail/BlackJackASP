import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GamePlayComponent } from '../components/game-play/game-play.component';

const routes: Routes = [
    { path: '', redirectTo: 'game-play', pathMatch: 'full' },
    { path: 'game-play', component: GamePlayComponent },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class GameRoutingModule { }