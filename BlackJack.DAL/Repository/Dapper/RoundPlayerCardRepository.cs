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
    public class RoundPlayerCardRepository : IRoundPlayerCardRepository
    {

        protected readonly string _connectionString;

        public RoundPlayerCardRepository(IOptions<DbSettingsOptions> options)
        {
            _connectionString = options.Value.ConnectionString;
        }

        public int Create(Models.RoundPlayerCard item)
        {
            var sqlQuery = @"INSERT INTO RoundPlayerCards (NumberCard, RoundPlayerId, CardId)
                VALUES(@NumberCard, @RoundPlayerId, @CardId); SELECT CAST(SCOPE_IDENTITY() as int)";
            using (var connection = new SqlConnection(_connectionString))
            {
                int? id = connection.QuerySingle<int>(sqlQuery, item);
                return id.Value;
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sqlQuery = "DELETE FROM RoundPlayerCards WHERE Id = @id";
                connection.Execute(sqlQuery, new { id });
            }
        }

        public Models.RoundPlayerCard Get(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var roundPlayerCard = connection.QuerySingle<RoundPlayerCard>("SELECT * FROM RoundPlayerCards WHERE Id = @id", new { id });
                return Mapper.ToModel(roundPlayerCard);
            }
        }

        public IEnumerable<Models.RoundPlayerCard> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var roundPlayerCards = connection.Query<RoundPlayerCard>("SELECT * FROM RoundPlayerCards");
                return Mapper.ToModel(roundPlayerCards);
            }
        }

        public IEnumerable<Models.RoundPlayerCard> GetCardsByRoundPlayer(int idRoundPlayer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var roundPlayerCards = connection.Query<RoundPlayerCard>("SELECT * FROM RoundPlayerCards WHERE RoundPlayerId = @idRoundPlayer",
                    new { idRoundPlayer });
                return Mapper.ToModel(roundPlayerCards);
            }
        }

        public int GetCountCardsByRoundPlayer(int idRoundPlayer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var roundPlayerCards = connection.Query<RoundPlayerCard>("SELECT * FROM RoundPlayerCards WHERE RoundPlayerId = @idRoundPlayer",
                    new { idRoundPlayer });
                return roundPlayerCards.Count();
            }
        }
    }
}