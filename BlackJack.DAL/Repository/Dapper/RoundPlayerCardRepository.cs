using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Dapper;

namespace BlackJack.DAL.Repository.Dapper
{
    public class RoundPlayerCardRepository : IRoundPlayerCardRepository
    {

        protected readonly DbConnection _dbConnection;

        public RoundPlayerCardRepository(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public int Create(Models.RoundPlayerCard item)
        {
            var sqlQuery = "INSERT INTO RoundPlayerCards (NumberCard, RoundPlayerId, CardId)" +
                "VALUES(@NumberCard, @RoundPlayerId, @CardId); SELECT CAST(SCOPE_IDENTITY() as int)";
            int? id = _dbConnection.Query<int>(sqlQuery, item).FirstOrDefault();
            return id.Value;
        }

        public void Delete(int id)
        {
            var sqlQuery = "DELETE FROM RoundPlayerCards WHERE Id = @id";
            _dbConnection.Execute(sqlQuery, new { id });
        }

        public Models.RoundPlayerCard Get(int id)
        {
            var roundPlayerCard = _dbConnection.Query<RoundPlayerCard>("SELECT * FROM RoundPlayerCards WHERE Id = @id", new { id }).FirstOrDefault();
            return Mapper.ToModel(roundPlayerCard);
        }

        public IEnumerable<Models.RoundPlayerCard> GetAll()
        {
            var roundPlayerCards = _dbConnection.Query<RoundPlayerCard>("SELECT * FROM RoundPlayerCards");
            return Mapper.ToModel(roundPlayerCards);
        }

        public IEnumerable<Models.RoundPlayerCard> GetCardsByRoundPlayer(int idRoundPlayer)
        {
            var roundPlayerCards = _dbConnection.Query<RoundPlayerCard>("SELECT * FROM RoundPlayerCards WHERE RoundPlayerId = @idRoundPlayer",
                new { idRoundPlayer });
            return Mapper.ToModel(roundPlayerCards);
        }

        public int GetCountCardsByRoundPlayer(int idRoundPlayer)
        {
            var roundPlayerCards = _dbConnection.Query<RoundPlayerCard>("SELECT * FROM RoundPlayerCards WHERE RoundPlayerId = @idRoundPlayer",
                new { idRoundPlayer });
            return roundPlayerCards.Count();
        }
    }
}