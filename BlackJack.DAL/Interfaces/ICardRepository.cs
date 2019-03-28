using BlackJack.Shared.Models;

namespace BlackJack.DAL.Interfaces
{
    public interface ICardRepository 
    {
        Card Get(int id);
    }
}
