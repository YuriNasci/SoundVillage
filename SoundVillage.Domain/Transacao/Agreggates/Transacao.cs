using SoundVillage.Domain.Core.Abstracts;
using SoundVillage.Domain.Core.ValueObject;
using SoundVillage.Domain.Transacao.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Domain.Transacao.Agreggates
{
    public class Transacao: BaseEntity
    {
        public DateTime DataTransacao { get; set; }
        public Monetario Valor { get; set; }
        public String Descricao { get; set; }
        public Merchant Merchant { get; set; }
    }
}
