using System.Collections.Generic;

namespace BlackJack.BL.Services.Interfaces
{
    public interface IRoundService
    {
        void StartRound(int gameId, IEnumerable<int> playersId);
        IEnumerable<byte> GetCards(int gameId, List<bool> flags);
        IEnumerable<byte> GetScores(int gameId);
        IEnumerable<bool> GetFlagsIsGiveCard(int gameId, bool playerChoice);
        bool CheckIsRoundFinished(int gameId, IEnumerable<bool> flags);
        IEnumerable<bool> GetFlagsIsWin(int gameId);
    }
}
