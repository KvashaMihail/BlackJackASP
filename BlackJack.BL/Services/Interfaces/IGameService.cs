using BlackJack.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BL.Services.Interfaces
{
    public interface IGameService
    {
        Game Create(string name);
        IEnumerable<Game> ShowGames();
        IEnumerable<Player> GetPlayers(string playerName, int countBots);
    }
}
