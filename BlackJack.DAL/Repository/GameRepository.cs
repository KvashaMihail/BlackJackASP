using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;

namespace BlackJack.DAL.Repository
{
    public class GameRepository : IGameRepository
    {
        protected readonly BlackJackContext _context;

        public GameRepository(DbConnection connection)
        {
            _context = new BlackJackContext(connection);
        }

        public void Create(Game item)
        {
            _context.Games.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Game item = _context.Games.Find(id);
            if (item != null)
            {
                _context.Games.Remove(item);
                _context.SaveChanges();
            }
        }

        public Game Get(int id)
        {
            return _context.Games.Find(id);
        }

        public IEnumerable<Game> GetAll()
        {
            return _context.Games;
        }

        public void Update(Game item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
