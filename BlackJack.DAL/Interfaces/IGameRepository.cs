using BlackJack.Models;

namespace BlackJack.DAL.Interfaces
{
    public interface IGameRepository : IRepository<Game>
    {
        void Update(int gameId);
    }
}
