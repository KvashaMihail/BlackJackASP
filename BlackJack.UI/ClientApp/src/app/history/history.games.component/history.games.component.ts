import { Component, OnInit } from '@angular/core';
import { GameService } from 'src/app/shared/_services/game.service';
import { Game } from 'src/app/shared/_models/game.model';
import { RoundView } from 'src/app/shared/_viewModels/history/round.view';

@Component({
  selector: 'app-history',
  templateUrl: './history.games.component.html',
  styleUrls: ['./history.games.component.scss']
})
export class HistoryGamesComponent implements OnInit {
  
  games : Array<Game>;
  rounds: Array<RoundView>;

  constructor(public service : GameService) {
  }

  public ngOnInit(): void {
    this.service.getGames().subscribe(
      (games : Array<Game>) => this.games = games
    );
  }

  private showRounds(id : number) {
    console.log(id);
    this.service.getRounds(id).subscribe(
      (rounds: Array<RoundView>) => {
        this.rounds = rounds;
        console.log(rounds);
      } 
    );
  }
}
