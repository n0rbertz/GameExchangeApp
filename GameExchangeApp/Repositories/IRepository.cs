using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GameExchangeApp.Repositories
{
    public interface IRepository<T>
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        void Remove(int id);
    }
}
