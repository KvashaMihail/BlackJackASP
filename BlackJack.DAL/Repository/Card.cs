using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;

namespace BlackJack.DAL.Repository
{
    public class CardRepository : ICardRepository
    {

        protected readonly BlackJackContext _context;

        public CardRepository(DbConnection connection)
        {
            _context = new BlackJackContext(connection);
        }

        public Shared.Models.Card Get(int id)
        {
            return Mapper.ToModel(_context.Cards.Find(id));
        }
    }
}