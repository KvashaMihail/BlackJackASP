using BlackJack.Models;

namespace BlackJack.DAL.Interfaces
{
    public interface IRoundRepository : IRepository<Round>
    {
        void Update(Round item);
        int GetCountRoundsByGame(int gameId);
        int GetIdbyNumber(int gameId, int number);
    }
}
