using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Dapper;

namespace BlackJack.DAL.Repository.Dapper
{
    public class RoundPlayerRepository : IRoundPlayerRepository
    {

        protected readonly DbConnection _dbConnection;

        public RoundPlayerRepository(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }


        public int Create(Models.RoundPlayer item)
        {
            var sqlQuery = "INSERT INTO RoundPlayers (RoundId, PlayerId)" +
                "VALUES(@RoundId, @PlayerId); SELECT CAST(SCOPE_IDENTITY() as int)";
            int? id = _dbConnection.Query<int>(sqlQuery, item).FirstOrDefault();
            return id.Value;
        }

        public void Delete(int id)
        {
            var sqlQuery = "DELETE FROM RoundPlayers WHERE Id = @id";
            _dbConnection.Execute(sqlQuery, new { id });
        }

        public Models.RoundPlayer Get(int id)
        {
            var roundPlayer = _dbConnection.Query<RoundPlayer>("SELECT * FROM RoundPlayers WHERE Id = @id", new { id }).FirstOrDefault();
            return Mapper.ToModel(roundPlayer);
        }

        public IEnumerable<Models.RoundPlayer> GetAll()
        {
            var roundPlayers = _dbConnection.Query<RoundPlayer>("SELECT * FROM RoundPlayers");
            return Mapper.ToModel(roundPlayers);
        }

        public IEnumerable<Models.RoundPlayer> GetRoundPlayersByRound(int roundId)
        {
            var roundPlayers = _dbConnection.Query<RoundPlayer>("SELECT * FROM RoundPlayers WHERE RoundId = @roundId", new { roundId });
            return Mapper.ToModel(roundPlayers);
        }

        public Models.RoundPlayer GetPlayer(int roundId, int playerId)
        {
            var roundPlayer = _dbConnection.Query<RoundPlayer>("SELECT * FROM RoundPlayers WHERE RoundId = @roundId" + 
                " AND PlayerId = @playerId", new { roundId, playerId }).FirstOrDefault();
            return Mapper.ToModel(roundPlayer);
        }

        public void Update(Models.RoundPlayer item)
        {
            var sqlQuery = "UPDATE RoundPlayers SET IsWin = @IsWin WHERE Id = @Id";
            _dbConnection.Execute(sqlQuery, item);
        }
    }
}