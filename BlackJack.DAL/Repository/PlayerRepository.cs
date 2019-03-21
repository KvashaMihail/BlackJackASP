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
        private BlackJackContext _context;

        public PlayerRepository() 
        {
            _context = new BlackJackContext();
        }

        public void Create(Player item)
        {
            _context.Players.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Player item = _context.Players.Find(id);
            if (item != null)
            {
                _context.Players.Remove(item);
                _context.SaveChanges();
            }
        }

        public Player Get(string name)
        {
            return _context.Players.Where(p => p.Name == name).FirstOrDefault();
        }

        public Player Get(int id)
        {
            return _context.Players.Find(id);
        }

        public IEnumerable<Player> GetAll()
        {
            return _context.Players;
        }

        public void Update(Player item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
