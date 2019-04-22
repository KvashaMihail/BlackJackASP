import { Component, Input } from '@angular/core';
import { Player } from 'src/app/models/Player';

@Component({
  selector: 'app-player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.scss']
})
export class PlayerComponent {

  @Input() player: Player;
  @Input() cards: Array<number>;
  @Input() score: number;

  constructor() {
  }
}
