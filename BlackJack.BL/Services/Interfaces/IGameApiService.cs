using BlackJack.ViewModels.Game;
using System.Collections.Generic;

namespace BlackJack.BL.Services.Interfaces
{
    public interface IGameApiService
    {
        PlayerStatsViewModel GetCards();
        PlayerStatsViewModel GetStartCards();
        PlayerStatsViewModel GetLastCards();
        void StartRound();
        List<bool> GetFlagsIsWin();
        List<RoundViewModel> GetRoundsViewModel(int gameId);
    }
}
