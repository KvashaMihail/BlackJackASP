using System.Collections.Generic;

namespace BlackJack.BL.Services.Interfaces
{
    public interface IRoundService
    {
        void StartRound(int gameId, IEnumerable<int> playersId);
    }
}
