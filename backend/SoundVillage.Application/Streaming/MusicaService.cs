using SoundVillage.Domain.Conta;
using SoundVillage.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Application.Streaming
{
    public class MusicaService
    {
        private MusicaRepository MusicaRepository { get; set; }
        private PlaylistRepository PlaylistRepository { get; set; }
        private UsuarioRepository UsuarioRepository { get; set; }

        public MusicaService(MusicaRepository musicaRepository, PlaylistRepository playlistRepository, UsuarioRepository usuarioRepository
            )
        {
            this.MusicaRepository = musicaRepository;
            this.PlaylistRepository = playlistRepository;
            this.UsuarioRepository = usuarioRepository;
        }

        public void FavoritarMusica(Guid IdMusica, Guid IdUsuario)
        {
            var usuario = UsuarioRepository.GetById(IdUsuario);
            var playlistFavoritas = usuario.Playlists.FirstOrDefault
                (p => p.Nome == "Favoritas");

            if (playlistFavoritas != null)
            {
                Playlist playlistFavoritasAtualizada = playlistFavoritas;
                var musica = MusicaRepository.GetById(IdMusica);

                if (!playlistFavoritasAtualizada.Musicas.Contains(musica))
                    playlistFavoritasAtualizada.Musicas.Add(musica);
                else
                    playlistFavoritasAtualizada.Musicas.Remove(musica);

                this.PlaylistRepository.Update(playlistFavoritasAtualizada);
            }
        }
    }
}
