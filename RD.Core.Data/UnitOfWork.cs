using RD.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RD.Core.Data
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private readonly ApplicationDbContext applicationDbContext;
        public UnitOfWork(ApplicationDbContext context)
        {
           
            applicationDbContext = context;
        }
        public async Task CompleteAsync()
        {
          await  applicationDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            applicationDbContext.Dispose();
        }
    }
}
