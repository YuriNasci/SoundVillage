using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Domain.Core.Abstracts
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}
