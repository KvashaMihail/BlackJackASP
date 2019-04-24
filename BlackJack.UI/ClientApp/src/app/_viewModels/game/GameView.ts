import { Game } from 'src/app/_models/Game';
import { Player } from 'src/app/_models/Player';

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