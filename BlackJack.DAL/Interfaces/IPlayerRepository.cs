using BlackJack.Models;
using System.Collections.Generic;

namespace BlackJack.DAL.Interfaces
{
    public interface IPlayerRepository : IRepository<Player>
    {      
        Player Get(string name);
        Player GetDealer();
        IEnumerable<Player> GetPlayers();
        IEnumerable<Player> GetBots(int countBots);
        bool GetIsEmptyByName(string name);
    }
}
