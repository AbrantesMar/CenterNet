using CenterIRepository;
using System;
using System.Collections.Generic;

namespace CenterRepository
{
    public abstract class BaseRepository<T> where T : class
    {
        private List<T> _entity;

        public BaseRepository()
        {
            this._entity = new List<T>();
        }

        public void Add(T obj)
        {
            _entity.Add(obj);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return _entity;
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(T obj)
        {
            _entity.Remove(obj);
        }

        public void Update(T obj)
        {
        }
    }
}
