import { Component, OnInit } from '@angular/core';
import { GameService } from 'src/app/shared/_services/game.service';
import { PlayerMenuView } from 'src/app/shared/_viewModels/game/player.menu.view';
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

  public ngOnInit(): void {
    this.service.getPlayerMenu().subscribe(
      (response: PlayerMenuView) => {
        console.log(`Get unfinished game: ${response.isAnyUnfinishedGame}`);
        this.isAnyUnfinishedGame = response.isAnyUnfinishedGame;
      }
    );
  }

  private newGame() {
    this.service.newGame(this.countBots).subscribe(
      () => this.router.navigateByUrl('/game/game-play')
    );
  }

  private continueGame() {
    this.service.continueGame().subscribe(
      () => this.router.navigateByUrl('/game/game-play')
    );
  }

  private showGames() {
    this.router.navigateByUrl('/history');
  }
}
