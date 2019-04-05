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
            game.DateFinishLastRound = DateTime.Now;
            var sqlQuery = "INSERT INTO Games (Name, DateStart, DateFinishLastRound)" +
                "VALUES(@Name, @DateStart, @DateFinishLastRound); SELECT CAST(SCOPE_IDENTITY() as int)";
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
            var game = _dbConnection.Query<Game>("SELECT * FROM Games WHERE Id = @id", new { id }).FirstOrDefault();
            return Mapper.ToModel(game);
        }

        public IEnumerable<Models.Game> GetAll()
        {
            var games = _dbConnection.Query<Game>("SELECT * FROM Games");
            return Mapper.ToModel(games);
        }

        public void Update(int gameId)
        {
            var sqlQuery = "UPDATE Games SET DateFinishLastRound = @DateFinishLastRound WHERE Id = @Id";
            Game game = new Game { Id = gameId, DateFinishLastRound = DateTime.Now };
            _dbConnection.Execute(sqlQuery, game);
        }
    }
}
