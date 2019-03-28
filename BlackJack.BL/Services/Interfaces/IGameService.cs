using BlackJack.Shared.Models;
using System.Collections.Generic;

namespace BlackJack.BL.Services.Interfaces
{
    public interface IGameService
    {
        Game Create(string name);
        IEnumerable<Game> ShowGames();
        IEnumerable<Player> GetPlayers(string playerName, int countBots);
    }
}
