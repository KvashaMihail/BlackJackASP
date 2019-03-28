using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;

namespace BlackJack.DAL.Repository
{
    public class RoundPlayerCardRepository : IRoundPlayerCardRepository
    {

        protected readonly BlackJackContext _context;

        public RoundPlayerCardRepository(DbConnection connection)
        {
            _context = new BlackJackContext(connection);
        }

        public void Create(RoundPlayerCard item)
        {
            _context.RoundPlayerCards.Add(item);
            _context.SaveChanges();
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

        public RoundPlayerCard Get(int id)
        {
            return _context.RoundPlayerCards.Find(id);
        }

        public IEnumerable<RoundPlayerCard> GetAll()
        {
            return _context.RoundPlayerCards;
        }

        public void Update(RoundPlayerCard item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}