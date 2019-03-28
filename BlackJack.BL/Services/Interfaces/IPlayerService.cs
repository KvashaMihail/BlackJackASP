using BlackJack.Shared.Models;
using System.Collections.Generic;

namespace BlackJack.BL.Services.Interfaces
{
    public interface IPlayerService
    {
        Player SelectOrCreate(string name);
        IEnumerable<Player> ShowPlayers();
    }
}
