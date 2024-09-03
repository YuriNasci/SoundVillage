using Microsoft.Extensions.Configuration;

namespace SoundVillage.Repository.Repository
{
    public class ArtistaRepository : CosmosDBContext
    {
        public ArtistaRepository(IConfiguration configuration) : base(configuration)
        {
            this.SetContainer("artista");
        }
    }
}
