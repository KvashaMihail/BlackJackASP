using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
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

        public int Create(Models.Game item)
        {
            Game game = Mapper.ToEntity(item);
            game.DateStart = DateTime.Now;
            game.DateEnd = DateTime.Now;
            _context.Games.Add(game);
            _context.SaveChanges();
            return game.Id;
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

        public Models.Game Get(int id)
        {
            return Mapper.ToModel(_context.Games.Find(id));
        }

        public IEnumerable<Models.Game> GetAll()
        {
            return Mapper.ToModel(_context.Games);
        }

        public void Update(Models.Game item)
        {

            _context.Entry(Mapper.ToEntity(item)).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
