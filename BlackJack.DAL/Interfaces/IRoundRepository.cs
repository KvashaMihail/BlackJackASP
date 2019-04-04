using BlackJack.Models;
using System.Collections.Generic;

namespace BlackJack.DAL.Interfaces
{
    public interface IRoundRepository : IRepository<Round>
    {
        void Update(Round item);
        IEnumerable<Round> GetRoundsByGame(int gameId);
        int GetCountRoundsByGame(int gameId);
        int GetIdbyNumber(int gameId, int number);
    }
}
