using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using BlackJack.Shared.Options;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BlackJack.DAL.Repository.Dapper
{
    public class RoundRepository : IRoundRepository
    {

        protected readonly string _connectionString;

        public RoundRepository(IOptions<DbSettingsOptions> options)
        {
            _connectionString = options.Value.ConnectionString;
        }


        public int Create(Models.Round item)
        {
            var sqlQuery = @"INSERT INTO Rounds (NumberRound, GameId, IsCompleted)
                VALUES(@NumberRound, @GameId, @IsCompleted); SELECT CAST(SCOPE_IDENTITY() as int)";
            item.IsCompleted = false;
            using (var connection = new SqlConnection(_connectionString))
            {
                int? id = connection.QuerySingle<int>(sqlQuery, item);
                return id.Value;
            }
        }

        public void Delete(int id)
        {
            var sqlQuery = "DELETE FROM Rounds WHERE Id = @id";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(sqlQuery, new { id });
            }
        }

        public Models.Round Get(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var round = connection.QuerySingle<Round>("SELECT * FROM Rounds WHERE Id = @id", new { id });
                return Mapper.ToModel(round);
            }
        }

        public IEnumerable<Models.Round> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var rounds = connection.Query<Round>("SELECT * FROM Rounds");
                return Mapper.ToModel(rounds);
            }
        }

        public int GetCountRoundsByGame(int gameId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var rounds = connection.Query<Round>("SELECT * FROM Rounds WHERE GameId = @gameId", new { gameId });
                return rounds.Count();
            }
        }

        public int GetIdbyNumber(int gameId, int number)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var round = connection.QuerySingle<Round>("SELECT * FROM Rounds WHERE GameId = @gameId AND NumberRound = @number",
                    new { gameId, number });
                return round.Id;
            }
        }

        public IEnumerable<Models.Round> GetRoundsByGame(int gameId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var rounds = connection.Query<Round>("SELECT * FROM Rounds WHERE GameId = @gameId", new { gameId });
                return Mapper.ToModel(rounds);
            }
        }

        public void Update(Models.Round item)
        {
            var sqlQuery = "UPDATE Rounds SET IsCompleted = @IsCompleted WHERE Id = @Id";
            item.IsCompleted = true;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(sqlQuery, item);
            }
        }
    }
}