using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace BlackJack.DAL.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        
        protected readonly BlackJackContext _context;

        public PlayerRepository(DbConnection connection)
        {
            _context = new BlackJackContext(connection);
        }


        public void Create(Shared.Models.Player item)
        {
            Player player = Mapper.ToEntity(item);
            _context.Players.Add(player);
            _context.SaveChanges();
            item = Mapper.ToModel(player);
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

        public Shared.Models.Player Get(int id)
        {
            return Mapper.ToModel(_context.Players.Find(id));
        }

        public IEnumerable<Shared.Models.Player> GetAll()
        {
            return Mapper.ToModel(_context.Players);
        }

        public void Update(Shared.Models.Player item)
        {

            _context.Entry(Mapper.ToEntity(item)).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<Shared.Models.Player> GetPlayers()
        {
            return Mapper.ToModel(_context.Players.Where(p => p.IsBot == false));
        }

        public IEnumerable<Shared.Models.Player> GetBots(int countBots)
        {
            return Mapper.ToModel(_context.Players.Where(p => p.Id <= countBots));
        }

        public Shared.Models.Player Get(string name)
        {
            return Mapper.ToModel(_context.Players.Where(p => p.Name == name).FirstOrDefault());
        }
    }
}
