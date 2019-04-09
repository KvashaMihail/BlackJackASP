using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using Dapper;
using System.Data.Common;
using System.Linq;

namespace BlackJack.DAL.Repository.Dapper
{
    public class CardRepository : ICardRepository
    {

        protected readonly DbConnection _dbConnection;

        public CardRepository(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Models.Card Get(byte id)
        {
            var card = _dbConnection.QuerySingle<Card>("SELECT * FROM Cards WHERE Id = @id", new { id });
            return Mapper.ToModel(card);
        }
    }
}