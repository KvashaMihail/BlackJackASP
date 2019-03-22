using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.DAL.Repository
{
    public class PlayerRepository : IRepository<Player>, IPlayerRepository
    {
        private DbContext _context;

        public PlayerRepository(DbContext dbContext) 
        {
            _context = dbContext;
        }

        //public PlayerRepository() 
        //{
        //    _context = new BlackJackContext();
        //}

        public void Create(Player item)
        {
            _context.Set<Player>().Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Player item = _context.Set<Player>().Find(id);
            if (item != null)
            {
                _context.Set<Player>().Remove(item);
                _context.SaveChanges();
            }
        }

        public Player Get(string name)
        {
            return _context.Set<Player>().Where(p => p.Name == name).FirstOrDefault();
        }

        public Player Get(int id)
        {
            return _context.Set<Player>().Find(id);
        }

        public IEnumerable<Player> GetAll()
        {
            return _context.Set<Player>();
        }

        public void Update(Player item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<Player> GetPlayers()
        {
            return _context.Set<Player>().Where(p => p.IsBot == false);
        }
    }
}
