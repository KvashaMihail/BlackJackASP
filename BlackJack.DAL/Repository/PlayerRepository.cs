using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace BlackJack.DAL.Repository
{
    public class PlayerRepository : IRepository<Player>, IPlayerRepository
    {
        
        protected readonly BlackJackContext _context;

        public PlayerRepository(DbConnection connection)
        {
            _context = new BlackJackContext(connection);
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

        public IEnumerable<Player> GetPlayers()
        {
            return _context.Players.Where(p => p.IsBot == false);
        }
    }
}
