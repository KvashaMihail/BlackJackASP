import { Component, OnInit } from '@angular/core';
import { GameService } from 'src/app/_services/game';
import { PlayerMenuView } from 'src/app/_viewModels/game/PlayerMenuView';
import { Router } from '@angular/router';


@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {

  isAnyUnfinishedGame: boolean;
  countBots: number;

  constructor(private service: GameService, private router: Router) {
  }

  ngOnInit(): void {
    this.service.getPlayerMenu().subscribe(
      (response: PlayerMenuView) => {
        console.log(response);
        this.isAnyUnfinishedGame = response.isAnyUnfinishedGame;
      }
    );
  }

  newGame() {
    this.service.newGame(this.countBots).subscribe(
      () => this.router.navigateByUrl('/game/gamePlay')
    );
  }

  continueGame() {
    this.service.continueGame().subscribe(
      () => this.router.navigateByUrl('/game/gamePlay')
    );
  }

  showGames() {
    this.router.navigateByUrl('/game/history');
  }
}
