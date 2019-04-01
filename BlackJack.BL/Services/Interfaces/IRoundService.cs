using System.Collections.Generic;

namespace BlackJack.BL.Services.Interfaces
{
    public interface IRoundService
    {
        void StartRound(int gameId, IEnumerable<int> playersId);
        IEnumerable<byte> GetCards(int gameId);
        IEnumerable<byte> GetScores(int gameId);
        IEnumerable<bool> GetFlagsIsGiveCard(int gameId, bool playerChoice);
        bool EndCheck(int gameId, IEnumerable<bool> flags);
    }
}
