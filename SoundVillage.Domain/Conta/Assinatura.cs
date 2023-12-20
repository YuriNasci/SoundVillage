﻿using SoundVillage.Domain.Core.Abstracts;
using SoundVillage.Domain.Streaming.Agreggates;
using SoundVillage.Domain.Transacao.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Domain.Conta
{
    public class Assinatura: BaseEntity
    {
        public Plano Plano { get; set; }
        public DateTime Validade { get; set; }
        public Cartao CartaoPagamento { get; set; }
        public bool IsAtual {  get; set; }
    }
}
