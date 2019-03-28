using BlackJack.BL.Models;
using BlackJack.BL.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;

namespace BlackJack.BL.Services
{
    public class CacheService : ICacheService
    {
        private IMemoryCache _cache;
        public CacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void SetPlayers(IEnumerable<Player> players)
        {
            
            var idPlayers = new List<int>();
            foreach (Player player in players)
            {
                idPlayers.Add(player.Id);
            }
            _cache.Set<List<int>>(1, idPlayers);
        }

        public IEnumerable<int> GetIdPlayers()
        {
            return _cache.Get<IEnumerable<int>>(1);
        }

        public void RemovePlayers()
        {
            _cache.Remove(1);
        }
    }
}
