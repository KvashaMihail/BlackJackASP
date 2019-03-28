using System.Collections.Generic;

namespace BlackJack.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(ref T item);
        void Update(T item);
        void Delete(int id);
    }
}
