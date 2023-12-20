using SoundVillage.Domain.Core.Abstracts;
using SoundVillage.Domain.Transacao.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Domain.Conta
{
    public class ContaStreaming: BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public List<Cartao> Cartoes {  get; set; }
        public List<Assinatura> Assinaturas { get; set;}
        public List<Playlist> Playlists { get; set; }
    }
}
