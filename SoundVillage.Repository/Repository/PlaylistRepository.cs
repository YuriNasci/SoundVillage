using SoundVillage.Domain.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Repository.Repository
{
    public class PlaylistRepository : RepositoryBase<Playlist>
    {
        public PlaylistRepository(SoundVillageContext context) : base(context)
        {
        }
    }
}
