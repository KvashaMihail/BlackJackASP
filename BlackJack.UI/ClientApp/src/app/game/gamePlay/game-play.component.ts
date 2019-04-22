import { Component, OnInit } from '@angular/core';
import { GameService } from 'src/app/services/game';
import { GameView } from 'src/app/viewModels/game/GameView';
import { GameStepView } from 'src/app/viewModels/game/GameStepView';

@Component({
  selector: 'app-gamePlay',
  templateUrl: './game-play.component.html',
  styleUrls: ['./game-play.component.scss']
})
export class GamePlayComponent implements OnInit {

  constructor(public service: GameService) {
  }

  ngOnInit(): void {
    if (this.service.gameView.cards == null) {
      this.service.getStartCards().subscribe(
        () => {
          console.log("Success");
        },
        error => console.log(error)
      );
    }
  }
  
  hit(): void {
    this.service.getCards().subscribe(
      () => {},
      error => console.log(error)
    );
  }

}
