using System.Collections.Generic;

namespace BlackJack.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        int Create(T item);
        void Update(int id, T item);
        void Delete(int id);
    }
}
