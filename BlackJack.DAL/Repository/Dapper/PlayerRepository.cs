using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using BlackJack.Shared.Options;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BlackJack.DAL.Repository.Dapper
{
    public class PlayerRepository : IPlayerRepository
    {

        protected readonly string _connectionString;

        public PlayerRepository(IOptions<DbSettingsOptions> options)
        {
            _connectionString = options.Value.ConnectionString;
        }


        public int Create(Models.Player item)
        {
            Player player = Mapper.ToEntity(item);
            player.IsBot = false;
            var sqlQuery = @"INSERT INTO Players (Name, IsBot)
                VALUES(@Name, @IsBot); SELECT CAST(SCOPE_IDENTITY() as int)";
            using (var connection = new SqlConnection(_connectionString))
            {
                int? id = connection.QuerySingle<int>(sqlQuery, player);
                return id.Value;
            }
        }

        public void Delete(int id)
        {
            var sqlQuery = "DELETE FROM Players WHERE Id = @id";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(sqlQuery, new { id });
            }
        }

        public Models.Player Get(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var player = connection.QuerySingle<Player>("SELECT * FROM Players WHERE Id = @id", new { id });
                return Mapper.ToModel(player);
            }
        }

        public IEnumerable<Models.Player> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var players = connection.Query<Player>("SELECT * FROM Players");
                return Mapper.ToModel(players);
            }
        }

        public IEnumerable<Models.Player> GetPlayers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var players = connection.Query<Player>("SELECT * FROM Players WHERE IsBot = 'false'");
                return Mapper.ToModel(players);
            }
        }

        public IEnumerable<Models.Player> GetBots(int countBots)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var players = connection.Query<Player>("SELECT * FROM Players WHERE Id <= @Count", new { Count = countBots });
                return Mapper.ToModel(players);
            }
        }

        public Models.Player Get(string name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var player = connection.QuerySingle<Player>("SELECT * FROM Players WHERE Name = @Name", new { Name = name });
                return Mapper.ToModel(player);
            }
        }

        public bool GetIsEmptyByName(string name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var player = connection.QueryFirstOrDefault<Player>("SELECT * FROM Players WHERE Name = @name", new { name });
                return player == null;
            }
        }

        public Models.Player GetDealer()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var player = connection.QuerySingle<Player>("SELECT * FROM Players WHERE Id = 8");
                return Mapper.ToModel(player);
            }
        }
    }
}
