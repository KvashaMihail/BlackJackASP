using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace BlackJack.DAL.Repository.EntityFramework
{
    public class RoundPlayerCardRepository : IRoundPlayerCardRepository
    {

        protected readonly BlackJackContext _context;

        public RoundPlayerCardRepository(BlackJackContext context)
        {
            _context = context;
        }

        public int Create(Models.RoundPlayerCard item)
        {
            RoundPlayerCard roundPlayerCard = Mapper.ToEntity(item);
            _context.RoundPlayerCards.Add(roundPlayerCard);
            _context.SaveChanges();
            return roundPlayerCard.Id;
        }

        public void Delete(int id)
        {
            RoundPlayerCard item = _context.RoundPlayerCards.Find(id);
            if (item != null)
            {
                _context.RoundPlayerCards.Remove(item);
                _context.SaveChanges();
            }
        }

        public Models.RoundPlayerCard Get(int id)
        {
            return Mapper.ToModel(_context.RoundPlayerCards.Find(id));
        }

        public IEnumerable<Models.RoundPlayerCard> GetAll()
        {
            return Mapper.ToModel(_context.RoundPlayerCards);
        }

        public IEnumerable<Models.RoundPlayerCard> GetCardsByRoundPlayer(int idRoundPlayer)
        {
            return Mapper.ToModel(_context.RoundPlayerCards.Where(rpc => rpc.RoundPlayerId == idRoundPlayer));
        }

        public int GetCountCardsByRoundPlayer(int idRoundPlayer)
        {
            return _context.RoundPlayerCards.Where(rpc => rpc.RoundPlayerId == idRoundPlayer).Count();
        }
    }
}