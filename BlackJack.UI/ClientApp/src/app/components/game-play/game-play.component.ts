import { Component, OnInit } from '@angular/core';
import { GameService } from 'src/app/_services/game';

@Component({
  selector: 'app-game-play',
  templateUrl: './game-play.component.html',
  styleUrls: ['./game-play.component.scss']
})
export class GamePlayComponent implements OnInit {


  constructor(public service: GameService) {
    
  }

  ngOnInit(): void {
    if (this.service.gameView.game == null) {
      console.log("Reload this page? Do not do it this way. Loading the current game");
      this.service.continueGame().subscribe(() => {
        if (this.service.gameView.cards == null) {
          console.log("Cards is null. Get start cards..");
          this.service.getStartCards();
        }
      });
    } 
    else 
    {
      if (this.service.gameView.cards == null) {
        console.log("Cards is null. Get start cards..");
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
