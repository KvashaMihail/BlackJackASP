using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;

namespace BlackJack.DAL.Repository
{
    public class RoundRepository : IRoundRepository
    {

        protected readonly BlackJackContext _context;

        public RoundRepository(DbConnection connection)
        {
            _context = new BlackJackContext(connection);
        }


        public void Create(Round item)
        {
            _context.Rounds.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Round item = _context.Rounds.Find(id);
            if (item != null)
            {
                _context.Rounds.Remove(item);
                _context.SaveChanges();
            }
        }

        public Round Get(int id)
        {
            return _context.Rounds.Find(id);
        }

        public IEnumerable<Round> GetAll()
        {
            return _context.Rounds;
        }

        public void Update(Round item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}