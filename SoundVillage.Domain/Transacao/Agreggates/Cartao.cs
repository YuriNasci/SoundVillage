using SoundVillage.Domain.Core.Abstracts;
using SoundVillage.Domain.Core.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Domain.Transacao.Agreggates
{
    public class Cartao: BaseEntity
    {
        public bool Ativo { get; set; }
        public String Numero { get; set; }
        public List<Transacao> Transacoes { get; set; } = new List<Transacao>();
    }
}
