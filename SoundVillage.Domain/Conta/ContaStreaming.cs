using SoundVillage.Domain.Core.Abstracts;
using SoundVillage.Domain.Core.Extension;
using SoundVillage.Domain.Core.ValueObjects;
using SoundVillage.Domain.Streaming.Agreggates;
using SoundVillage.Domain.Streaming.ValueObject;
using SoundVillage.Domain.Transacao.Aggregates;
using SoundVillage.Domain.Transacao.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Domain.Conta
{
    public class ContaStreaming : BaseEntity
    {
        private const string NOME_PLAYLIST = "Favoritas";
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        //public virtual List<Cartao> Cartoes { get; set; } = new List<Cartao>();
        //public virtual List<Assinatura> Assinaturas { get; set; } = new List<Assinatura>();
        //public virtual List<Playlist> Playlists { get; set; } = new List<Playlist>();
    }
}