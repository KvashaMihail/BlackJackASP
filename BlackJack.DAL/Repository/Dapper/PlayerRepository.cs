using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;

namespace BlackJack.DAL.Repository.Dapper
{
    public class PlayerRepository : IPlayerRepository
    {

        protected readonly DbConnection _dbConnection;

        public PlayerRepository(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }


        public int Create(Models.Player item)
        {
            Player player = Mapper.ToEntity(item);
            player.IsBot = false;
            var sqlQuery = @"INSERT INTO Players (Name, IsBot)
                VALUES(@Name, @IsBot); SELECT CAST(SCOPE_IDENTITY() as int)";
            int? id = _dbConnection.QuerySingle<int>(sqlQuery, player);
            return id.Value;
        }

        public void Delete(int id)
        {
            var sqlQuery = "DELETE FROM Players WHERE Id = @id";
            _dbConnection.Execute(sqlQuery, new { id });
        }

        public Models.Player Get(int id)
        {
            var player = _dbConnection.QuerySingle<Player>("SELECT * FROM Players WHERE Id = @id", new { id });
            return Mapper.ToModel(player);
        }

        public IEnumerable<Models.Player> GetAll()
        {
            var players = _dbConnection.Query<Player>("SELECT * FROM Players");
            return Mapper.ToModel(players);
        }

        public IEnumerable<Models.Player> GetPlayers()
        {
            var players = _dbConnection.Query<Player>("SELECT * FROM Players WHERE IsBot = 'false'");
            return Mapper.ToModel(players);
        }

        public IEnumerable<Models.Player> GetBots(int countBots)
        {
            var players = _dbConnection.Query<Player>("SELECT * FROM Players WHERE Id <= @Count", new { Count = countBots });
            return Mapper.ToModel(players);
        }

        public Models.Player Get(string name)
        {
            var player = _dbConnection.QuerySingle<Player>("SELECT * FROM Players WHERE Name = @Name", new { Name = name });
            return Mapper.ToModel(player);
        }

        public bool GetIsEmptyByName(string name)
        {
            Debug.WriteLine(name);
            var player = _dbConnection.QueryFirstOrDefault<Player>("SELECT * FROM Players WHERE Name = @name", new { name });
            return player == null;
        }

        public Models.Player GetDealer()
        {
            var player = _dbConnection.QuerySingle<Player>("SELECT * FROM Players WHERE Id = 8");
            return Mapper.ToModel(player);
        }
    }
}
