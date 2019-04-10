using BlackJack.Models;
using BlackJack.ViewModels.Api;
using BlackJack.ViewModels.Game;
using System.Collections.Generic;

namespace BlackJack.BL.Services.Interfaces
{
    public interface IGameMenuService
    {
        GameViewModel CreateGameViewModel(int countBots);
        GameViewModel GetGameViewModel();
        PlayerMenuViewModel GetPlayerMenuViewModel();
        IEnumerable<Game> GetGames();
        void FinishGame();
    }
}
