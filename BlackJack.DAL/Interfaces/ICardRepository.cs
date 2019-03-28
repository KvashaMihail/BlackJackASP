using BlackJack.Models;

namespace BlackJack.DAL.Interfaces
{
    public interface ICardRepository 
    {
        Card Get(int id);
    }
}
