import { Component, Input } from '@angular/core';
import { Player } from 'src/app/_models/Player';
import { PlayerState } from 'src/app/_enums/player-state';

@Component({
  selector: 'app-player',
  templateUrl: './player-details.component.html',
  styleUrls: ['./player-details.component.scss']
})
export class PlayerDetailsComponent {

  @Input() player: Player;
  @Input() cards?: Array<number>;
  @Input() score: number;
  @Input() state: PlayerState;
  @Input() isFinished: boolean;
  @Input() id: number;
  @Input() idDealer: number;

  readonly colorClasses: string[][] = [
    [ 'border-primary', 'border-success', 'border-danger' ],
    [ 'alert-primary' , 'alert-success', 'alert-danger' ]
  ];
  readonly isMargin: string[] = ["", "margin-left-minus"];
}