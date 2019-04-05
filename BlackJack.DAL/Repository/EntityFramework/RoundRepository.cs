using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace BlackJack.DAL.Repository.EntityFramework
{
    public class RoundRepository : IRoundRepository
    {

        protected readonly BlackJackContext _context;

        public RoundRepository(BlackJackContext context)
        {
            _context = context;
        }


        public int Create(Models.Round item)
        {
            Round round = Mapper.ToEntity(item);
            _context.Rounds.Add(round);
            _context.SaveChanges();
            return round.Id;
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

        public Models.Round Get(int id)
        {
            return Mapper.ToModel(_context.Rounds.Find(id));
        }

        public IEnumerable<Models.Round> GetAll()
        {
            return Mapper.ToModel(_context.Rounds);
        }

        public int GetCountRoundsByGame(int gameId)
        {
            return _context.Rounds.Where(round => round.GameId == gameId).Count();
        }

        public int GetIdbyNumber(int gameId, int number)
        {
            return _context.Rounds
                .Where(round => ((round.GameId == gameId) && round.NumberRound == number))
                .FirstOrDefault().Id;
        }

        public IEnumerable<Models.Round> GetRoundsByGame(int gameId)
        {
            return Mapper.ToModel(_context.Rounds.Where(round => round.GameId == gameId));
        }

        public void Update(Models.Round item)
        {
            var entity = _context.Rounds.FirstOrDefault(r => r.Id == item.Id);
            entity.IsCompleted = true;
            _context.SaveChanges();
        }
    }
}