using SoundVillage.Domain.Transacao.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Domain.Conta.Agreggates
{
    public class Usuario
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        
        public List<Cartao> Cartoes { get; set; } = new List<Cartao>();

        public List<Playlist> Playlists { get; set; } = new List<Playlist>();
        public List<Assinatura> Assinaturas { get; set; } = new List<Assinatura>();

    }
}
