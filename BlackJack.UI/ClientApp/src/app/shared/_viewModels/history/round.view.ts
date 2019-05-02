import { Round } from 'src/app/shared/_models/round.model';

export class RoundView {
    round? : Round;
    players? : Array<string>;
    scores? : Array<number>;
    isWins? : Array<boolean>;
    cards? : Array<Array<number>>;
}
