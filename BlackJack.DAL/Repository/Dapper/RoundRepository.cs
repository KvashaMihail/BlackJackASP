using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Dapper;

namespace BlackJack.DAL.Repository.Dapper
{
    public class RoundRepository : IRoundRepository
    {

        protected readonly DbConnection _dbConnection;

        public RoundRepository(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }


        public int Create(Models.Round item)
        {
            var sqlQuery = @"INSERT INTO Rounds (NumberRound, GameId, IsCompleted)
                VALUES(@NumberRound, @GameId, @IsCompleted); SELECT CAST(SCOPE_IDENTITY() as int)";
            item.IsCompleted = false;
            int? id = _dbConnection.QuerySingle<int>(sqlQuery, item);
            return id.Value;
        }

        public void Delete(int id)
        {
            var sqlQuery = "DELETE FROM Rounds WHERE Id = @id";
            _dbConnection.Execute(sqlQuery, new { id });
        }

        public Models.Round Get(int id)
        {
            var round = _dbConnection.QuerySingle<Round>("SELECT * FROM Rounds WHERE Id = @id", new { id });
            return Mapper.ToModel(round);
        }

        public IEnumerable<Models.Round> GetAll()
        {
            var rounds = _dbConnection.Query<Round>("SELECT * FROM Rounds");
            return Mapper.ToModel(rounds);
        }

        public int GetCountRoundsByGame(int gameId)
        {
            var rounds = _dbConnection.Query<Round>("SELECT * FROM Rounds WHERE GameId = @gameId", new { gameId });
            return rounds.Count();
        }

        public int GetIdbyNumber(int gameId, int number)
        {
            var round = _dbConnection.QuerySingle<Round>("SELECT * FROM Rounds WHERE GameId = @gameId AND NumberRound = @number",
                new { gameId, number });
            return round.Id;
        }

        public IEnumerable<Models.Round> GetRoundsByGame(int gameId)
        {
            var rounds = _dbConnection.Query<Round>("SELECT * FROM Rounds WHERE GameId = @gameId", new { gameId });
            return Mapper.ToModel(rounds);
        }

        public void Update(Models.Round item)
        {
            var sqlQuery = "UPDATE Rounds SET IsCompleted = @IsCompleted WHERE Id = @Id";
            item.IsCompleted = true;
            _dbConnection.Execute(sqlQuery, item);
        }
    }
}