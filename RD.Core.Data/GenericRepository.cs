using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RD.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await this.dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await this.dbSet.ToListAsync<T>();
        }

        public async Task<T> GetById(Guid id)
        {
            return await this.dbSet.Where<T>(d => d.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Upsert(T entity)
        {
            try
            {
               var existingUser= await dbSet.Where(d => d.Id == entity.Id).FirstOrDefaultAsync();
               var properties= typeof(T).GetProperties();
                foreach(var prop in properties)
                {
                    if (prop.DeclaringType == typeof(Entity)||prop.Name==nameof(Entity.Id))
                    {
                        continue;
                    }
                   var updateValue= prop.GetValue(entity);
                    prop.SetValue(existingUser, updateValue);
                
                }

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
