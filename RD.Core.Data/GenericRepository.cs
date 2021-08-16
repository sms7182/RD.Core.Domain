using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RD.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RD.Core.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : AggregateEntity
    {
        protected ApplicationDbContext context;
        internal DbSet<T> dbSet;
        public GenericRepository(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
            dbSet = this.context.Set<T>();

        }


        public virtual async Task<bool> Add(T entity)
        {
           await dbSet.AddAsync(entity);
            return true;
        }   

        public virtual async Task<bool> Delete(Guid id)
        {
          var entity= await dbSet.FirstAsync<T>(d => d.Id == id);
            if (entity != null)
            {
                dbSet.Remove(entity);
                return true;
            }
            return false;
            
           
        }

        public Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
