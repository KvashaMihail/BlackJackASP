import { Game } from 'src/app/shared/_models/game.model';
import { Player } from 'src/app/shared/_models/player.model';

export class GameView {

    constructor() {
        this.game = null;
        this.players = null;
        this.cards = null;
        this.scores = null;
    }

    game? : Game;
    players? : Array<Player>;
    cards? : Array<Array<number>>;
    scores? : Array<number>;
}