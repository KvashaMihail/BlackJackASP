using BlackJack.ViewModels.Api;
using System.Collections.Generic;

namespace BlackJack.BL.Services.Interfaces
{
    public interface IGameApiService
    {
        PlayerStatsViewModel GetCards(int gameId);
        PlayerStatsViewModel GetStartCards(int gameId);
        PlayerStatsViewModel GetLastCards(int gameId);
        void StartRound(int gameId);
        List<bool> GetFlagsIsWin(int gameId);
        List<RoundViewModel> GetRoundsViewModel(int gameId);

    }
}
