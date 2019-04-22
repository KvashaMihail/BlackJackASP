using BlackJack.Models;
using BlackJack.ViewModels.Game;
using BlackJack.ViewModels.Menu;
using System.Collections.Generic;

namespace BlackJack.BL.Services.Interfaces
{
    public interface IGameService
    {
        Game Create(string name);
        Player SelectPlayer(string name);
        void FinishGame(int gameId);
        IEnumerable<Game> GetGames();
        IEnumerable<Player> GetPlayers(string playerName, int countBots);
        List<string> GetNamePlayers(List<int> playersId);
        Game GetCurrentGame(string playerName);
        int GetCurrentGameId(string playerName);
        PlayerMenuViewModel GetPlayerMenu(string playerName);
    }
}
