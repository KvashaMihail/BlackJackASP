import { Round } from 'src/app/_models/Round';

export class RoundView {
    round? : Round;
    players? : Array<string>;
    scores? : Array<number>;
    isWins? : Array<boolean>;
    cards? : Array<Array<number>>;
}
