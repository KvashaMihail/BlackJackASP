using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using BlackJack.Shared.Options;
using Dapper;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;

namespace BlackJack.DAL.Repository.Dapper
{
    public class CardRepository : ICardRepository
    {

        protected readonly string _connectionString;
        public CardRepository(IOptions<DbSettingsOptions> options)
        {
            _connectionString = options.Value.ConnectionString;
        }

        public Models.Card Get(byte id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var card = connection.QuerySingle<Card>("SELECT * FROM Cards WHERE Id = @id", new { id });
                return Mapper.ToModel(card);
            }
        }
    }
}