using GameExchangeApp.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameExchangeApp.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<ActionResult<TEntity>> GetById(string id);
        Task<ActionResult<IEnumerable<TEntity>>> GetAll();        
        void Add(TEntity entity);
        public void Save();
    }
}
