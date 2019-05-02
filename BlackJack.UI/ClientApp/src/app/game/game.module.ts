
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameRoutingModule } from './game.routing.module';
import { GamePlayComponent } from './game.play.component/game.play.component';
import { PlayerDetailsComponent } from './game.play.component/player.details.component/player.details.component';
import { FormsModule } from '@angular/forms';


@NgModule({
    declarations: [
      GamePlayComponent,
      PlayerDetailsComponent,
    ],
  imports: [
    CommonModule,
    FormsModule,
    GameRoutingModule
  ]
})
export class GameModule { }