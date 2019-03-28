using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace BlackJack.DAL.Repository
{
    public class RoundRepository : IRoundRepository
    {

        protected readonly BlackJackContext _context;

        public RoundRepository(DbConnection connection)
        {
            _context = new BlackJackContext(connection);
        }


        public void Create(ref Shared.Models.Round item)
        {
            Round round = Mapper.ToEntity(item);
            _context.Rounds.Add(round);
            _context.SaveChanges();
            item = Mapper.ToModel(round);
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

        public Shared.Models.Round Get(int id)
        {
            return Mapper.ToModel(_context.Rounds.Find(id));
        }

        public IEnumerable<Shared.Models.Round> GetAll()
        {
            return Mapper.ToModel(_context.Rounds);
        }

        public int GetCountRoundsByGame(int gameId)
        {
            return _context.Rounds.Where(round => round.GameId == gameId).Count();
        }

        public void Update(Shared.Models.Round item)
        {

            _context.Entry(Mapper.ToEntity(item)).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}