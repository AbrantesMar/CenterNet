using System.Collections.Generic;

namespace CenterIService
{
    public interface IService<T> where T : class
    {
        void Add(T param);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Update(T obj);
        void Remove(T obj);
        void Dispose();
    }
}
