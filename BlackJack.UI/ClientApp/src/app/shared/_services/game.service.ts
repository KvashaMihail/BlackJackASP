import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GameView } from '../_viewModels/game/game.view';
import { map } from 'rxjs/operators';
import { GameStepView } from '../_viewModels/game/game.step.view';

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
    this.gameView = new GameView();
  }

  public getPlayerMenu() {
    return this.http.get(`${this.UrlMenu}GetPlayerMenu`);
  }

  public newGame(countBots: number) {
    this.refresh();
    this.isFinishedRound = false;
    return this.http.get(`${this.UrlMenu}StartGame/${countBots}`).pipe(
      map((gameView: GameView) => this.gameView = gameView)
      );
  }

  public continueGame() {
    this.refresh();
    return this.http.get(`${this.UrlMenu}ContinueGame`).pipe(
      map((gameView: GameView) => this.gameView = gameView)
    );
  }

  public getStartCards() {
    return this.http.get(`${this.UrlGame}GetStartCards`).subscribe(
      (gameStepView: GameStepView) => {
        this.gameView.scores = gameStepView.scores;
        this.gameView.cards = gameStepView.cards;
      });
  }

  private nextStep(gameStepView: GameStepView) {
    this.gameView.scores = gameStepView.scores;
    this.isFinishedRound = gameStepView.isFinishedRound;
    if (gameStepView.isFinishedRound) {
      this.getResults();  
    }
    var i: any;
    for(i in this.gameView.cards) {
      let cards = this.gameView.cards[i].concat(gameStepView.cards[i]);
      this.gameView.cards[i] = cards;
    }
    if ((gameStepView.scores[0] >= 21) && (!gameStepView.isFinishedRound)) {
      this.getLastCards();  
    }
  }

  public getResults() {
    return this.http.get(`${this.UrlGame}GetPlayerStates`).subscribe(
      (states: Array<number>) => {
        this.resultPlayers = states;
      });
  }

  public getCards() {
    return this.http.get(`${this.UrlGame}GetCards`).subscribe(
      (gameStepView: GameStepView) => this.nextStep(gameStepView)
    );
  }

  public getLastCards() {
    return this.http.get(`${this.UrlGame}GetLastCards`).subscribe(
      (gameStepView: GameStepView) => this.nextStep(gameStepView)
    );
  }

  public refresh() {
    this.isFinishedRound = false;
    this.resultPlayers = [0, 0, 0, 0, 0, 0, 0, 0];
  }

  public nextRound() {
    return this.http.get(`${this.UrlGame}StartNextRound`).subscribe(
      (gameStepView: GameStepView) => {
        this.gameView.cards = gameStepView.cards;
        this.gameView.scores = gameStepView.scores;
      });
  }

  public finishGame() {
    return this.http.post(`${this.UrlGame}FinishGame`, {}).subscribe(() => {});
  }

  public getGames() {
    return this.http.get(`${this.UrlMenu}GetGames`);
  }

  public getRounds(id : number) {
    return this.http.get(`${this.UrlGame}GetRounds/${id}`);
  }
}
