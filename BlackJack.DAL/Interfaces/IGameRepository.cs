using BlackJack.DAL.Entities;

namespace BlackJack.DAL.Interfaces
{
    public interface IGameRepository : IRepository<Game>
    {
        Game Get(string name);
    }
}
