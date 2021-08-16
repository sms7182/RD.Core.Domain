using System;
using System.Collections.Generic;
using System.Text;

namespace RD.Core.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
