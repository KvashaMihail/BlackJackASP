using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace BlackJack.DAL.Repository.Dapper
{
    public class GameRepository : IGameRepository
    {
        protected readonly DbConnection _dbConnection;

        public GameRepository(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public int Create(Models.Game item)
        {
            Game game = Mapper.ToEntity(item);
            game.DateStart = DateTime.Now;
            game.DateEnd = DateTime.Now;
            var sqlQuery = @"INSERT INTO Games (Name, DateStart, DateEnd)
                VALUES(@Name, @DateStart, @DateEnd); SELECT CAST(SCOPE_IDENTITY() as int)";
            int? id = _dbConnection.Query<int>(sqlQuery, game).FirstOrDefault();
            return id.Value;
        }

        public void Delete(int id)
        {
            var sqlQuery = "DELETE FROM Games WHERE Id = @id";
            _dbConnection.Execute(sqlQuery, new { id });
        }

        public Models.Game Get(int id)
        {
            var game = _dbConnection.QuerySingle<Game>("SELECT * FROM Games WHERE Id = @id", new { id });
            return Mapper.ToModel(game);
        }

        public IEnumerable<Models.Game> GetAll()
        {
            var games = _dbConnection.Query<Game>("SELECT * FROM Games");
            return Mapper.ToModel(games);
        }

        public bool GetIsEmptyById(int id)
        {
            var game = _dbConnection.Query<Game>("SELECT * FROM Games WHERE Id = @id", new { id });
            return !game.Any();
        }

        public void Update(int gameId)
        {
            var sqlQuery = "UPDATE Games SET DateEnd = @DateEnd, IsFinished = @IsFinished WHERE Id = @Id";
            Game game = new Game { Id = gameId, DateEnd = DateTime.Now, IsFinished = true };
            _dbConnection.Execute(sqlQuery, game);
        }

        public IEnumerable<Models.Game> GetGamesByPlayerId(int playerId)
        {
            var sqlQuery = @"SELECT * FROM games 
                             WHERE  Games.Id in ( 
                                SELECT Rounds.GameId FROM Rounds
                                WHERE  Rounds.Id in ( 
                                    SELECT RoundPlayers.RoundId	FROM RoundPlayers
                                    WHERE RoundPlayers.PlayerId = @Id))";
            var games = _dbConnection.Query<Game>(sqlQuery, new { Id = playerId });
            if (games == null)
            {
                return null;
            }
            return Mapper.ToModel(games);
        }

        public Models.Game GetUnfinishedGameByPlayerId(int playerId)
        {
            var sqlQuery = @"SELECT * FROM games 
                             WHERE Games.IsFinished = 'false' AND Games.Id in ( 
                                SELECT Rounds.GameId FROM Rounds
                                WHERE  Rounds.Id in ( 
                                    SELECT RoundPlayers.RoundId	FROM RoundPlayers
                                    WHERE RoundPlayers.PlayerId = @Id))";
            var game = _dbConnection.QueryFirstOrDefault<Game>(sqlQuery, new { Id = playerId });
            if (game == null)
            {
                return null;
            }
            return Mapper.ToModel(game);
        }
    }
}
