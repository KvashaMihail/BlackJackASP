import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GameView } from '../_viewModels/game/GameView';
import { map } from 'rxjs/operators';
import { GameStepView } from '../_viewModels/game/GameStepView';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class GameService {

  public gameView: GameView;
  public isFinishedRound : boolean = false;
  public resultPlayers : Array<number> = [0, 0, 0, 0, 0, 0, 0, 0];

  private UrlMenu = 'api/Menu/';
  private UrlGame = 'api/Game/';

  constructor(private http: HttpClient) {
  }

  getPlayerMenu() {
    return this.http.get(`${this.UrlMenu}GetPlayerMenu`);
  }

  newGame(countBots: number) {
    this.isFinishedRound = false;
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

  nextStep(gameStepView: GameStepView) {
    this.gameView.scores = gameStepView.scores;
    this.isFinishedRound = gameStepView.isFinishedRound;
    if (gameStepView.isFinishedRound) {
      this.getResults().subscribe(() => {});  
    }
    var i: any;
    for(i in this.gameView.cards) {
      let cards = this.gameView.cards[i].concat(gameStepView.cards[i]);
      this.gameView.cards[i] = cards;
    }
    if ((gameStepView.scores[0] >= 21) && (!gameStepView.isFinishedRound)) {
      this.getLastCards().subscribe(() => {});  
    }
  }

  getResults() {
    return this.http.get(`${this.UrlGame}GetPlayerStates`).pipe(
      map((states: Array<number>) => {
        this.resultPlayers = states;
      }));
  }

  getCards() {
    return this.http.get(`${this.UrlGame}GetCards`).pipe(
      map((gameStepView: GameStepView) => this.nextStep(gameStepView))
    );
  }

  getLastCards() {
    return this.http.get(`${this.UrlGame}GetLastCards`).pipe(
      map((gameStepView: GameStepView) => this.nextStep(gameStepView))
    );
  }

  refresh() {
    this.isFinishedRound = false;
    this.resultPlayers = [0, 0, 0, 0, 0, 0, 0, 0];
  }

  nextRound() {
    return this.http.get(`${this.UrlGame}StartNextRound`).pipe(
      map((gameStepView: GameStepView) => {
        this.gameView.cards = gameStepView.cards;
        this.gameView.scores = gameStepView.scores;
      })
    );
  }

  finishGame() {
    return this.http.post(`${this.UrlGame}FinishGame`, {});
  }

  getGames() {
    return this.http.get(`${this.UrlMenu}GetGames`);
  }

  getRounds(id : number) {
    return this.http.post(`${this.UrlGame}GetRounds`, {gameId: id});
  }
}
