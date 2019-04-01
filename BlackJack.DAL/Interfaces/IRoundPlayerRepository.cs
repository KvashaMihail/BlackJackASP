using BlackJack.Models;
using System.Collections.Generic;

namespace BlackJack.DAL.Interfaces
{
    public interface IRoundPlayerRepository : IRepository<RoundPlayer>
    {
        IEnumerable<RoundPlayer> GetRoundPlayersByRound(int roundId);
        RoundPlayer GetPlayer(int roundId, int playerId);
    }
}
