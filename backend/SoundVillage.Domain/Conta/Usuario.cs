using SoundVillage.Domain.Core.Extension;
using SoundVillage.Domain.Core.ValueObjects;
using SoundVillage.Domain.Streaming.Aggregates;
using SoundVillage.Domain.Streaming.Agreggates;
using SoundVillage.Domain.Transacao.Agreggates;
using SoundVillage.Domain.Transacao.ValueObject;

namespace SoundVillage.Domain.Conta.Agreggates
{
    public class Usuario
    {

        private const string NOME_PLAYLIST = "Favoritas";

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DtNascimento { get; set; }
        public virtual IList<Cartao> Cartoes { get; set; } = new List<Cartao>();
        public virtual IList<Assinatura> Assinaturas { get; set; } = new List<Assinatura>();
        public virtual IList<Playlist> Playlists { get; set; } = new List<Playlist>();
        public virtual IList<Notificacao.Notificacao> Notificacoes { get; set; } = new List<Notificacao.Notificacao>();


        public void CriarConta(string nome, string email, string senha, DateTime dtNascimento, Plano plano, Cartao cartao)
        {
            this.Nome = nome;
            this.Email = email;
            this.DtNascimento = dtNascimento;

            //Criptografar a senha
            this.Senha = this.CriptografarSenha(senha);

            //Assinar um plano
            this.AssinarPlano(plano, cartao);

            //Adicionar cartão na conta do usuário
            this.AdicionarCartao(cartao);

            //Criar a playlist padrão do usuario
            this.CriarPlaylist(nome: NOME_PLAYLIST, publica: false);


        }

        public void CriarPlaylist(string nome, bool publica = true)
        {
            this.Playlists.Add(new Playlist()
            {
                Nome = nome,
                Usuario = this
            });
        }

        private void AdicionarCartao(Cartao cartao) 
            => this.Cartoes.Add(cartao);

        private void AssinarPlano(Plano plano, Cartao cartao)
        {
            //Debitar o valor do plano no cartao
            cartao.CriarTransacao(new Merchant() { Nome = plano.Nome }, new Monetario(plano.Valor), plano.Descricao);

            //Desativo caso tenha alguma assinatura ativa
            DesativarAssinaturaAtiva();

            //Adiciona uma nova assinatura
            this.Assinaturas.Add(new Assinatura()
            {
                IsAtual = true,
                Plano = plano,
            });

        }

        private void DesativarAssinaturaAtiva()
        {
            //Caso tenha alguma assintura ativa, deseativa ela
            if (this.Assinaturas.Count > 0 && this.Assinaturas.Any(x => x.IsAtual))
            {
                var planoAtivo = this.Assinaturas.FirstOrDefault(x => x.IsAtual);
                if (planoAtivo != null ) planoAtivo.IsAtual = false;
            }
        }

        private String CriptografarSenha(string senhaAberta)
        {
            return senhaAberta.HashSHA256();
        }

        public Playlist GetFavoritas()
        {
            return this.Playlists.First(p => p.Nome == NOME_PLAYLIST);
        }
    }
}
