using SoundVillage.Domain.Core.Abstracts;
using SoundVillage.Domain.Core.ValueObject;
using SoundVillage.Domain.Streaming.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Domain.Streaming.Agreggates
{
    public class Plano: BaseEntity
    {
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public Monetario Valor { get; set; }

        public RecorrenciaPlano Recorrencia { get; set; }
    }
}
