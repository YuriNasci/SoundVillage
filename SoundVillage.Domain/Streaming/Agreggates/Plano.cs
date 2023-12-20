using SoundVillage.Domain.Core.Abstracts;
using SoundVillage.Domain.Core.ValueObjects;
using SoundVillage.Domain.Streaming.ValueObject;

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
