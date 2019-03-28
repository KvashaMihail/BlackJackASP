using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;

namespace BlackJack.DAL.Repository
{
    public class RoundPlayerRepository : IRoundPlayerRepository
    {

        protected readonly BlackJackContext _context;

        public RoundPlayerRepository(DbConnection connection)
        {
            _context = new BlackJackContext(connection);
        }


        public void Create(RoundPlayer item)
        {
            _context.RoundPlayers.Add(item);
            _context.SaveChanges();
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

        public RoundPlayer Get(int id)
        {
            return _context.RoundPlayers.Find(id);
        }

        public IEnumerable<RoundPlayer> GetAll()
        {
            return _context.RoundPlayers;
        }

        public void Update(RoundPlayer item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}