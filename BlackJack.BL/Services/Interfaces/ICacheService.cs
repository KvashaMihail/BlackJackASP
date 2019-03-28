using BlackJack.BL.Models; 
using System.Collections.Generic;

namespace BlackJack.BL.Services.Interfaces
{
    public interface ICacheService
    {
        void SetPlayers(IEnumerable<Player> players);
        IEnumerable<int> GetIdPlayers();
        void RemovePlayers();
    }
}
