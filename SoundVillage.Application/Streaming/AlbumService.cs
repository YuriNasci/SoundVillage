using SoundVillage.Application.Interface;
using SoundVillage.Domain.Streaming.Aggregates;
using SoundVillage.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Application.Streaming
{
    public class AlbumService : IAlbumService
    {
        public AlbumService(AlbumRepository albumRepository)
        {
            AlbumRepository = albumRepository;
        }

        private AlbumRepository AlbumRepository { get; set; }

        public IEnumerable<Album> ObterTodos()
        {
            return AlbumRepository.GetAll();
        }
    }
}
