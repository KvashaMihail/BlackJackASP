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
      this.service.continueGame().subscribe(() => {
        console.log("Check cards is null..");
        if (this.service.gameView.cards == null) {
          console.log("Get start cards..");
          this.service.getStartCards();
        }
      });
    } else {
      console.log("Check cards is null..");
      if (this.service.gameView.cards == null) {
        console.log("Get start cards..");
        this.service.getStartCards();
      }
    }

  }

  hit() {
    this.service.getCards();
  }

  stand() {
    this.service.getLastCards();
  }

  nextRound() {
    this.service.refresh();
    this.service.nextRound();
  }

  endGame() {
    this.service.finishGame();
  }






}
