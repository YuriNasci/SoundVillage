using SoundVillage.Domain.Streaming.Aggregates;
using SoundVillage.Repository.Interfaces;

namespace SoundVillage.Repository.Repository
{
    public class ArtistaRepository: RepositoryBase<Artista>, IArtistaRepository
    {
        public ArtistaRepository(SoundVillageContext context): base(context) { 
            
        }
    }
}
