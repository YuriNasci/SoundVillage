using SoundVillage.Domain.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Repository.Interfaces
{
    public interface IPlaylistRepository
    {
        void Update(Playlist playlistFavoritasAtualizada);
    }
}
