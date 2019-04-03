﻿using BlackJack.Models;
using System.Collections.Generic;

namespace BlackJack.BL.Services.Interfaces
{
    public interface IGameService
    {
        Game Create(string name);
        void UpdateTimeForGame(int gameId);
        IEnumerable<Game> ShowGames();
        IEnumerable<Player> GetPlayers(string playerName, int countBots);
    }
}
