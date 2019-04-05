using BlackJack.Models;
using BlackJack.ViewModels.Api;
using System.Collections.Generic;

namespace BlackJack.BL.Services.Interfaces
{
    public interface IGameMenuService
    {
        GameViewModel GetGameViewModel(int countBots, string playerName);
        IEnumerable<Game> GetGames();
    }
}
