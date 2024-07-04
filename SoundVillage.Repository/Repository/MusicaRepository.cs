using SoundVillage.Domain.Streaming.Aggregates;
using SoundVillage.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Repository.Repository
{
    public class MusicaRepository : RepositoryBase<Musica>, IMusicaRepository
    {
        public MusicaRepository(SoundVillageContext context) : base(context)
        {
        }
    }
}
