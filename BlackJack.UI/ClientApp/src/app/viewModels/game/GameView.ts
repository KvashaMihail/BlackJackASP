import { Game } from 'src/app/models/Game';
import { Player } from 'src/app/models/Player';

export class GameView {
    game? : Game;
    players? : Array<Player>;
    cards? : Array<Array<number>>;
    scores? : Array<number>;
}