using SoundVillage.Domain.Streaming.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Repository.Repository
{
    public class ArtistaRepository: RepositoryBase<Artista>
    {
        public ArtistaRepository(SoundVillageContext context): base(context) { 
            
        }
    }
}
