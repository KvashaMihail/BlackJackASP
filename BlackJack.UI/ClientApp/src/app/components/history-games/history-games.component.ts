import { Component, OnInit } from '@angular/core';
import { GameService } from 'src/app/_services/game';
import { Game } from 'src/app/_models/Game';
import { RoundView } from 'src/app/_viewModels/history/RoundView';

@Component({
  selector: 'app-history',
  templateUrl: './history-games.component.html',
  styleUrls: ['./history-games.component.scss']
})
export class HistoryGamesComponent implements OnInit {
  
  games : Array<Game>;
  rounds: Array<RoundView>;

  constructor(public service : GameService) {
  }

  ngOnInit(): void {
    this.service.getGames().subscribe(
      (games : Array<Game>) => this.games = games
    );
  }

  showRounds(id : number) {
    console.log(id);
    this.service.getRounds(id).subscribe(
      (rounds: Array<RoundView>) => {
        this.rounds = rounds;
        console.log(rounds);
      } 
    );
  }
}
