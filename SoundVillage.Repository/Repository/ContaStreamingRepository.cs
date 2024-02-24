using SoundVillage.Domain.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Repository.Repository
{
    public class ContaStreamingRepository: RepositoryBase<ContaStreaming>
    {
        public SoundVillageContext Context { get; set; }

        public ContaStreamingRepository(SoundVillageContext context): base(context) { 
            Context = context;
        }
    }
}
