using SoundVillage.Domain.Core.Abstracts;
using SoundVillage.Domain.Streaming.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Domain.Conta.Agreggates
{
    public class Assinatura: BaseEntity
    {
        public Plano Plano { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataAtivacao { get;set; }
        public DateTime DataExpiracao { get; set; }
        public bool RenovacaoAutomatica { get; set; }
    }
}
