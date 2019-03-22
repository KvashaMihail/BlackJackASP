using BlackJack.DAL.Entities;
using System.Collections.Generic;

namespace BlackJack.DAL.Interfaces
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Player Get(string name);
        IEnumerable<Player> GetPlayers();
    }
}
