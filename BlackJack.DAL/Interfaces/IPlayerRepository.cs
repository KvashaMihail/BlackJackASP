using BlackJack.Shared.Models;
using System.Collections.Generic;

namespace BlackJack.DAL.Interfaces
{
    public interface IPlayerRepository 
    {
        IEnumerable<Player> GetAll();
        Player Get(int id);
        void Create(Player item);
        void Update(Player item);
        void Delete(int id);
        Player Get(string name);
        IEnumerable<Player> GetPlayers();
        IEnumerable<Player> GetBots(int countBots);
    }
}
