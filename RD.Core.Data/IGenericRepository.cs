using RD.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RD.Core.Data
{
    public interface IGenericRepository<T> where T:AggregateEntity
    {
    }
}
