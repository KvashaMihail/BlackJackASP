using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using BlackJack.Shared.Options;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BlackJack.DAL.Repository.Dapper
{
    public class GameRepository : IGameRepository
    {
        protected readonly string _connectionString;

        public GameRepository(IOptions<DbSettingsOptions> options)
        {
            _connectionString = options.Value.ConnectionString;
        }

        public int Create(Models.Game item)
        {
            Game game = Mapper.ToEntity(item);
            game.DateStart = DateTime.Now;
            game.DateEnd = DateTime.Now;
            var sqlQuery = @"INSERT INTO Games (Name, DateStart, DateEnd)
                VALUES(@Name, @DateStart, @DateEnd); SELECT CAST(SCOPE_IDENTITY() as int)";
            using (var connection = new SqlConnection(_connectionString))
            {
                int? id = connection.Query<int>(sqlQuery, game).FirstOrDefault();
                return id.Value;
            }
        }

        public void Delete(int id)
        {
            var sqlQuery = "DELETE FROM Games WHERE Id = @id";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(sqlQuery, new { id });
            }
            
        }

        public Models.Game Get(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var game = connection.QuerySingle<Game>("SELECT * FROM Games WHERE Id = @id", new { id });
                return Mapper.ToModel(game);
            }
            
        }

        public IEnumerable<Models.Game> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var games = connection.Query<Game>("SELECT * FROM Games");
                return Mapper.ToModel(games);
            }
        }

        public bool GetIsEmptyById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var game = connection.Query<Game>("SELECT * FROM Games WHERE Id = @id", new { id });
                return !game.Any();
            }
        }

        public void Update(int gameId)
        {
            var sqlQuery = "UPDATE Games SET DateEnd = @DateEnd, IsFinished = @IsFinished WHERE Id = @Id";
            Game game = new Game { Id = gameId, DateEnd = DateTime.Now, IsFinished = true };
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(sqlQuery, game);
            }
        }

        public IEnumerable<Models.Game> GetGamesByPlayerId(int playerId)
        {
            var sqlQuery = @"SELECT * FROM games 
                             WHERE  Games.Id in ( 
                                SELECT Rounds.GameId FROM Rounds
                                WHERE  Rounds.Id in ( 
                                    SELECT RoundPlayers.RoundId	FROM RoundPlayers
                                    WHERE RoundPlayers.PlayerId = @Id))";
            using (var connection = new SqlConnection(_connectionString))
            {
                var games = connection.Query<Game>(sqlQuery, new { Id = playerId });
                if (games == null)
                {
                    return null;
                }
                return Mapper.ToModel(games);
            }
        }

        public Models.Game GetUnfinishedGameByPlayerId(int playerId)
        {
            var sqlQuery = @"SELECT * FROM games 
                             WHERE Games.IsFinished = 'false' AND Games.Id in ( 
                                SELECT Rounds.GameId FROM Rounds
                                WHERE  Rounds.Id in ( 
                                    SELECT RoundPlayers.RoundId	FROM RoundPlayers
                                    WHERE RoundPlayers.PlayerId = @Id))";
            using (var connection = new SqlConnection(_connectionString))
            {
                var game = connection.QueryFirstOrDefault<Game>(sqlQuery, new { Id = playerId });
                if (game == null)
                {
                    return null;
                }
                return Mapper.ToModel(game);
            }

        }
    }
}
