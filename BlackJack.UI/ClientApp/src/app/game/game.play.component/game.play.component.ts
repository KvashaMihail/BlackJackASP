import { Component, OnInit } from '@angular/core';
import { GameService } from 'src/app/shared/_services/game.service';

@Component({
  selector: 'app-game-play',
  templateUrl: './game.play.component.html',
  styleUrls: ['./game.play.component.scss']
})
export class GamePlayComponent implements OnInit {


  constructor(public service: GameService) {
    
  }

  public ngOnInit(): void {
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

  private hit() {
    this.service.getCards();
  }

  private stand() {
    this.service.getLastCards();
  }

  private nextRound() {
    this.service.refresh();
    this.service.nextRound();
  }

  private endGame() {
    this.service.finishGame();
  }






}
