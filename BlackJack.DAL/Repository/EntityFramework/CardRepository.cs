using BlackJack.DAL.EF;
using BlackJack.DAL.Interfaces;

namespace BlackJack.DAL.Repository.EntityFramework
{
    public class CardRepository : ICardRepository
    {

        protected readonly BlackJackContext _context;

        public CardRepository(BlackJackContext context)
        {
            _context = context;
        }

        public Models.Card Get(byte id)
        {
            return Mapper.ToModel(_context.Cards.Find(id));
        }
    }
}