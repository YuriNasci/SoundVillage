using SoundVillage.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Repository.Interfaces
{
    public interface IArtistaRepository
    {
        void Save(Artista artista);
        Artista GetById(Guid id);
        IEnumerable<Artista> GetAll();
        void Update(Artista artista);
        void Delete(Artista artista);
    }
}
