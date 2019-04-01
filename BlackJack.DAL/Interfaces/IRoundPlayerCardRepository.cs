using BlackJack.Models;
using System.Collections.Generic;

namespace BlackJack.DAL.Interfaces
{
    public interface IRoundPlayerCardRepository : IRepository<RoundPlayerCard>
    {
        IEnumerable<RoundPlayerCard> GetCardsByRoundPlayer(int idRoundPlayer);
        int GetCountCardsByRoundPlayer(int idRoundPlayer);
    }
}
