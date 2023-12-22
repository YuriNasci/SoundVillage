using SoundVillage.Domain.Core.Abstracts;
using SoundVillage.Domain.Core.ValueObjects;

namespace SoundVillage.Domain.Transacao.Aggregates
{
    public class Transacao: BaseEntity
    {
        public Monetario Valor { get; set; }
        public DateTime Horario { get; set; }
        public ContaBancaria ContaOrigem { get; set; }
        public ContaBancaria ContaDestino { get; set; }
        public string Descricao { get; internal set; }
    }
}