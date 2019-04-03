using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.DAL.Repository
{
    public class RoundPlayerRepository : IRoundPlayerRepository
    {

        protected readonly BlackJackContext _context;

        public RoundPlayerRepository(BlackJackContext context)
        {
            _context = context;
        }


        public int Create(Models.RoundPlayer item)
        {
            RoundPlayer roundPlayer = Mapper.ToEntity(item);
            _context.RoundPlayers.Add(roundPlayer);
            _context.SaveChanges();
            return roundPlayer.Id;
        }

        public void Delete(int id)
        {
            RoundPlayer item = _context.RoundPlayers.Find(id);
            if (item != null)
            {
                _context.RoundPlayers.Remove(item);
                _context.SaveChanges();
            }
        }

        public Models.RoundPlayer Get(int id)
        {
            return Mapper.ToModel(_context.RoundPlayers.Find(id));
        }

        public IEnumerable<Models.RoundPlayer> GetAll()
        {
            return Mapper.ToModel(_context.RoundPlayers);
        }

        public IEnumerable<Models.RoundPlayer> GetRoundPlayersByRound(int roundId)
        {
            return Mapper.ToModel(_context.RoundPlayers.Where(rp => rp.RoundId == roundId));
        }

        public Models.RoundPlayer GetPlayer(int roundId, int playerId)
        {
            return Mapper.ToModel(_context.RoundPlayers.Where(rp => rp.RoundId == roundId && rp.PlayerId == playerId).FirstOrDefault());
        }

        public void Update(Models.RoundPlayer item)
        {
            var entity = _context.RoundPlayers.FirstOrDefault(rp => rp.Id == item.Id);
            entity.IsWin = item.IsWin;
            _context.SaveChanges();
        }
    }
}