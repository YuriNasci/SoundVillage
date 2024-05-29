using SoundVillage.Domain.Streaming.Aggregates;

namespace SoundVillage.Repository.Repository
{
    public class ArtistaRepository: RepositoryBase<Artista>
    {
        public ArtistaRepository(SoundVillageContext context): base(context) { 
            
        }
    }
}
