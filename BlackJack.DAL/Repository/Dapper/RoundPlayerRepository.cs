using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using BlackJack.Shared.Options;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BlackJack.DAL.Repository.Dapper
{
    public class RoundPlayerRepository : IRoundPlayerRepository
    {

        protected readonly string _connectionString;

        public RoundPlayerRepository(IOptions<DbSettingsOptions> options)
        {
            _connectionString = options.Value.ConnectionString;
        }


        public int Create(Models.RoundPlayer item)
        {
            var sqlQuery = @"INSERT INTO RoundPlayers (RoundId, PlayerId)
                VALUES(@RoundId, @PlayerId); SELECT CAST(SCOPE_IDENTITY() as int)";
            using (var connection = new SqlConnection(_connectionString))
            {
                int? id = connection.QuerySingle<int>(sqlQuery, item);
                return id.Value;
            }
        }

        public void Delete(int id)
        {
            var sqlQuery = "DELETE FROM RoundPlayers WHERE Id = @id";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(sqlQuery, new { id });
            }
        }

        public Models.RoundPlayer Get(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var roundPlayer = connection.QuerySingle<RoundPlayer>("SELECT * FROM RoundPlayers WHERE Id = @id", new { id });
                return Mapper.ToModel(roundPlayer);
            }       
        }

        public IEnumerable<Models.RoundPlayer> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var roundPlayers = connection.Query<RoundPlayer>("SELECT * FROM RoundPlayers");
                return Mapper.ToModel(roundPlayers);
            }
        }

        public IEnumerable<Models.RoundPlayer> GetRoundPlayersByRound(int roundId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var roundPlayers = connection.Query<RoundPlayer>("SELECT * FROM RoundPlayers WHERE RoundId = @roundId", new { roundId });
                return Mapper.ToModel(roundPlayers);
            }
        }

        public Models.RoundPlayer GetPlayer(int roundId, int playerId)
        {
            var sql = @"SELECT * FROM RoundPlayers 
                        WHERE RoundId = @roundId AND PlayerId = @playerId";
            using (var connection = new SqlConnection(_connectionString))
            {
                var roundPlayer = connection.QuerySingle<RoundPlayer>(sql, new { roundId, playerId });
                return Mapper.ToModel(roundPlayer);
            }
        }

        public void Update(Models.RoundPlayer item)
        {
            var sqlQuery = "UPDATE RoundPlayers SET IsWin = @IsWin WHERE Id = @Id";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(sqlQuery, item);
            }
        }
    }
}