using SoundVillage.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Repository.Interfaces
{
    public interface IMusicaRepository
    {
        void Delete(Musica v);
        IEnumerable<Musica> GetAll();
        Musica GetById(Guid id);
        void Save(Musica musica);
        void Update(Musica musica);
    }
}
