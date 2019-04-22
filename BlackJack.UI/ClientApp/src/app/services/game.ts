import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GameView } from '../viewModels/game/GameView';
import { map } from 'rxjs/operators';
import { GameStepView } from '../viewModels/game/GameStepView';

@Injectable({
  providedIn: 'root',
})
export class GameService {

  public gameView: GameView;

  private UrlMenu = 'api/Menu/';
  private UrlGame = 'api/Game/';

  constructor(private http: HttpClient) {
  }

  getPlayerMenu() {
    return this.http.get(`${this.UrlMenu}GetPlayerMenu`);
  }

  newGame(countBots: number) {
    return this.http.post(`${this.UrlMenu}StartGame`, {countBots: countBots}).pipe(
      map((gameView: GameView) => this.gameView = gameView)
      );
  }

  continueGame() {
    return this.http.get(`${this.UrlMenu}ContinueGame`).pipe(
      map((gameView: GameView) => this.gameView = gameView)
    );
  }

  getStartCards() {
    return this.http.get(`${this.UrlGame}GetStartCards`).pipe(
      map((gameStepView: GameStepView) => {
        this.gameView.scores = gameStepView.scores;
        this.gameView.cards = gameStepView.cards;
      }
    ));
  }

  addStep(gameStepView: GameStepView) {
    this.gameView.scores = gameStepView.scores;
    var i: any;
    for(i in this.gameView.cards) {
      let cards = this.gameView.cards[i].concat(gameStepView.cards[i]);
      this.gameView.cards[i] = cards;
    }
    console.log(this.gameView);
  }

  getCards() {
    return this.http.get(`${this.UrlGame}GetCards`).pipe(
      map((gameStepView: GameStepView) => this.addStep(gameStepView))
    );
  }

  getLastCards() {

  }

}
