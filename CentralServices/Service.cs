using CenterIRepository;
using CenterIService;
using System;
using System.Collections.Generic;

namespace CentralServices
{
    public class Service<T> : IDisposable, IService<T> where T : class
    {
        private readonly IBaseRepository<T> _repository;

        public void Add(T param)
        {
            _repository.Add(param);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(T param)
        {
            _repository.Remove(param);
        }

        public void Update(T param)
        {
            _repository.Update(param);
        }
    }
}
