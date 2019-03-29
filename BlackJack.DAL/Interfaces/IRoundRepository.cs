﻿using BlackJack.Models;

namespace BlackJack.DAL.Interfaces
{
    public interface IRoundRepository :IRepository<Round>
    {
        int GetCountRoundsByGame(int gameId);
        int GetIdbyNumber(int gameId, int number);
    }
}
