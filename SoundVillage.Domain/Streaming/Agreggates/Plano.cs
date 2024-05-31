using SoundVillage.Domain.Core.Abstracts;
using SoundVillage.Domain.Core.ValueObjects;
using SoundVillage.Domain.Streaming.ValueObject;
using SoundVillage.Domain.Transacao.Aggregates;

namespace SoundVillage.Domain.Streaming.Agreggates
{
    public class Plano: BaseEntity
    {
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public Monetario Valor { get; set; }

        public virtual RecorrenciaPlano Recorrencia { get; set; }
        public virtual ContaBancaria ContaBancariaCobradora { get; set; }
    }
}
