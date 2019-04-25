
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameRoutingModule } from './game-routing.module';
import { GamePlayComponent } from '../components/game-play/game-play.component';
import { PlayerDetailsComponent } from '../components/game-play/player-details/player-details.component';
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