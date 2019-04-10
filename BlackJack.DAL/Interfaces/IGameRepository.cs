using BlackJack.Models;
using System.Collections.Generic;

namespace BlackJack.DAL.Interfaces
{
    public interface IGameRepository : IRepository<Game>
    {
        void Update(int gameId);
        bool GetIsEmptyById(int gameId);
        IEnumerable<Game> GetGamesByPlayerId(int playerId);
        Game GetUnfinishedGameByPlayerId(int playerId);
    }
}
