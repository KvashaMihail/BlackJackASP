using BlackJack.Models;
using System.Collections.Generic;

namespace BlackJack.BL.Services.Interfaces
{
    public interface IGameService
    {
        Game Create(string name);
        Player SelectPlayer(string name);
        void UpdateTimeForGame(int gameId);
        IEnumerable<Game> GetGames();
        IEnumerable<Player> GetPlayers(string playerName, int countBots);
        List<string> GetNamePlayers(List<int> playersId);
        bool GetIsEmptyById(int gameId);
    }
}
