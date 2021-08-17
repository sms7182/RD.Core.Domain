using System;
using System.Threading.Tasks;

namespace RD.Core.Domain
{
    public interface IUnitOfWork
    {   

        Task CompleteAsync();
    }
}
