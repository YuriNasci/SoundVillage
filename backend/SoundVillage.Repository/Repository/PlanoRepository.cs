using SoundVillage.Domain.Streaming.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Repository.Repository
{
    public class PlanoRepository: RepositoryBase<Plano>
    {
        public SoundVillageContext Context { get; set; }

        public PlanoRepository(SoundVillageContext context) : base(context)
        {
            Context = context;
        }
    }
}
