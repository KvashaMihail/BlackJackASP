import { Component, OnInit } from '@angular/core';
import { GameService } from 'src/app/_services/game';

@Component({
  selector: 'app-gamePlay',
  templateUrl: './game-play.component.html',
  styleUrls: ['./game-play.component.scss']
})
export class GamePlayComponent implements OnInit {

  
  constructor(public service: GameService) {
  }

  ngOnInit(): void {
    if (this.service.gameView == undefined) {
      this.service.continueGame().subscribe(
        () => {},
        error => console.log(error)
      );
    }
    if (this.service.gameView.cards == null) {
      this.service.getStartCards().subscribe(
        () => {},
        error => console.log(error)
      );
    }
  }
  
  hit() {
    this.service.getCards().subscribe(
      () => {},
      error => console.log(error)
    );
  }

  stand() {
    this.service.getLastCards().subscribe(
      () => {}
    );
  }

  nextRound() {
    this.service.refresh();
    this.service.nextRound().subscribe(() => {});
  }

  endGame() {
    this.service.finishGame().subscribe(() => {});
  }



  


}
