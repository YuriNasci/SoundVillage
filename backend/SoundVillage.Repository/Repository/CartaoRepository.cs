using SoundVillage.Domain.Transacao.Aggregates;
using SoundVillage.Domain.Transacao.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Repository.Repository
{
    public class CartaoRepository : RepositoryBase<Cartao>
    {
        public CartaoRepository(SoundVillageContext context) : base(context)
        {
        }

        public Cartao? GetByNumero(string numeroCartao)
        {
            return Context.Cartoes.FirstOrDefault(c => c.Numero == numeroCartao);
        }
    }
}
