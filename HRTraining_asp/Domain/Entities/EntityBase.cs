using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRTraining.Domain.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
    }
}
