using GameExchangeApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameExchangeApp.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal ApplicationDbContext context;
        internal DbSet<TEntity> dbset;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            this.dbset = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            dbset.Add(entity);
        }

        public async Task<ActionResult<IEnumerable<TEntity>>> GetAll()
        {
            return await dbset.ToListAsync();
        }

        public async Task<ActionResult<TEntity>> GetById(string id)
        {
            return await dbset.FindAsync(id);
        }

        public void Save()
        {
            context.SaveChangesAsync();
        }
    }
}
