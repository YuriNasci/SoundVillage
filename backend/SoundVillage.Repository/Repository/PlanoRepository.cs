using SoundVillage.Domain.Streaming.Agreggates;

namespace SoundVillage.Repository.Repository
{
    public class PlanoRepository: RepositoryBase<Plano>
    {
        public SoundVillageContext Context { get; set; }

        public PlanoRepository(SoundVillageContext context) : base(context)
        {
            Context = context;
        }
    }
}
