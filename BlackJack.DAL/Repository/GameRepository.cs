using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace BlackJack.DAL.Repository
{
    public class GameRepository : IGameRepository
    {
        protected readonly BlackJackContext _context;

        public GameRepository(DbConnection connection)
        {
            _context = new BlackJackContext(connection);
        }

        public void Create(ref Shared.Models.Game item)
        {
            Game game = Mapper.ToEntity(item);
            _context.Games.Add(game);
            _context.SaveChanges();
            item = Mapper.ToModel(game);
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

        public Shared.Models.Game Get(int id)
        {
            return Mapper.ToModel(_context.Games.Find(id));
        }

        public IEnumerable<Shared.Models.Game> GetAll()
        {
            return Mapper.ToModel(_context.Games);
        }

        public void Update(Shared.Models.Game item)
        {

            _context.Entry(Mapper.ToEntity(item)).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
