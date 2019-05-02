using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.DAL.Repository.EntityFramework
{
    public class GameRepository : IGameRepository
    {
        protected readonly BlackJackContext _context;

        public GameRepository(BlackJackContext context)
        {
            _context = context;
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

        public IEnumerable<Models.Game> GetGamesByPlayerId(int playerId)
        {
            var games = _context.Games
                .Where(g => g.Rounds == _context.Rounds
                    .Where(r => r.RoundPlayers == _context.RoundPlayers
                        .Where(rp => rp.PlayerId == playerId)));
            if (games == null)
            {
                return null;
            }
            return Mapper.ToModel(games);
        }

        public Models.Game GetUnfinishedGameByPlayerId(int playerId)
        {
            //var game = _context.Games
            //    .FirstOrDefault(g => !g.IsFinished && g.Rounds == _context.Rounds
            //        .Where(r => r.RoundPlayers == _context.RoundPlayers
            //            .Where(rp => rp.PlayerId == playerId)));
            var game = _context.Games.Where(g => !g.IsFinished)
                .Join(_context.Rounds
                    .Join(_context.RoundPlayers
                        .Where(rp => rp.PlayerId == playerId),
                        round => round.RoundPlayerId,
                        roundPlayer => roundPlayer.Id,
                        (round, roundPlayer) => round),
                    g => g.RoundId,
                    round => round.Id,
                    (g, round) => g).
                FirstOrDefault();
            return Mapper.ToModel(game);
        }

        public bool GetIsEmptyById(int id)
        {
            var game = _context.Games.Find(id);
            return game == null;
        }

        public void Update(int gameId)
        {
            var entity = _context.Games.FirstOrDefault(g => g.Id == gameId);
            entity.DateEnd = DateTime.Now;
            entity.IsFinished = true;
            _context.SaveChanges();
        }
    }
}
