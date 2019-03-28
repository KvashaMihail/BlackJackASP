using BlackJack.Shared.Models;

namespace BlackJack.DAL.Interfaces
{
    public interface IRoundRepository :IRepository<Round>
    {
        int GetCountRoundsByGame(int gameId);
    }
}
