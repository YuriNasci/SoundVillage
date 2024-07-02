using SoundVillage.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Repository.Repository
{
    public class AlbumRepository : RepositoryBase<Album>
    {
        public AlbumRepository(SoundVillageContext context) : base(context) { }
    }
}
