import { Component, Input } from '@angular/core';
import { Player } from 'src/app/_models/Player';
import { PlayerState } from 'src/app/_enums/player-state';

@Component({
  selector: 'app-player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.scss']
})
export class PlayerComponent {

  @Input() player: Player;
  @Input() cards: Array<number>;
  @Input() score: number;
  @Input() state: PlayerState;

  readonly colorClasses: string[][] = [
    [ 'border-primary', 'border-success', 'border-danger' ],
    [ 'alert-primary' , 'alert-success', 'alert-danger' ]
  ];
  constructor() {
  }
}
