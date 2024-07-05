using SoundVillage.Domain.Conta;
using SoundVillage.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Repository.Repository
{
    public class PlaylistRepository : RepositoryBase<Playlist>, IPlaylistRepository
    {
        public PlaylistRepository(SoundVillageContext context) : base(context)
        {
        }
    }
}
