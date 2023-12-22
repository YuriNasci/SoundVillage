using SoundVillage.Domain.Core.Abstracts;
using SoundVillage.Domain.Core.ValueObjects;
using SoundVillage.Domain.Streaming.Agreggates;
using SoundVillage.Domain.Streaming.ValueObject;
using SoundVillage.Domain.Transacao.Aggregates;
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
        public List<Cartao> Cartoes { get; set; } = new List<Cartao>();
        public List<Assinatura> Assinaturas { get; set; } = new List<Assinatura>();
        public List<Playlist> Playlists { get; set; } = new List<Playlist>();

        public void CriarConta(string nome, string email, string senha, DateTime dtNascimento, Plano plano, Cartao cartao)
        {
            this.Nome = nome;
            this.Email = email;
            this.DataNascimento = dtNascimento;

            //Criptografar a senha
            this.Senha = this.CriptografarSenha(senha);

            //Assinar um plano
            this.AssinarPlano(plano, cartao);

            //Adicionar cartão na conta do usuário
            this.AdicionarCartao(cartao);

            //Criar a playlist padrão do usuario
            this.CriarPlaylist(nome: NOME_PLAYLIST);


        }
        public void CriarPlaylist(string nome)
        {
            this.Playlists.Add(new Playlist()
            {
                Nome = nome,
                Conta = this
            });
        }

        private void AdicionarCartao(Cartao cartao)
            => this.Cartoes.Add(cartao);

        public void AssinarPlano(Plano plano, Cartao cartao)
        {
            //Debitar o valor do plano no cartao
            cartao.CriarTransacao(plano.ContaBancariaCobradora, new Monetario(plano.Valor), plano.Descricao);

            //Desativo caso tenha alguma assinatura ativa
            DesativarAssinaturaAtiva();

            //Adiciona uma nova assinatura
            this.Assinaturas.Add(new Assinatura()
            {
                IsAtual = true,
                Plano = plano,
                Validade = GetValidadeByRecorrenciaPlano(plano.Recorrencia)
            });
        }

        private DateTime GetValidadeByRecorrenciaPlano(RecorrenciaPlano recorrencia)
        {
            switch (recorrencia)
            {
                case RecorrenciaPlano.MENSAL:
                    return DateTime.Now.AddMonths(1);

                case RecorrenciaPlano.TRIMESTRAL:
                    return DateTime.Now.AddMonths(3);

                case RecorrenciaPlano.ANUAL:
                    return DateTime.Now.AddYears(1);

                default:
                    throw new ArgumentOutOfRangeException(nameof(recorrencia), recorrencia, "Recorrência do plano desconhecida.");
            }
        }

        private void DesativarAssinaturaAtiva()
        {
            //Caso tenha alguma assintura ativa, deseativa ela
            if (this.Assinaturas.Count > 0 && this.Assinaturas.Any(x => x.IsAtual))
            {
                var planoAtivo = this.Assinaturas.FirstOrDefault(x => x.IsAtual);
                planoAtivo.IsAtual = false;
            }
        }

        private String CriptografarSenha(string senhaAberta)
        {
            SHA256 criptoProvider = SHA256.Create();

            byte[] btexto = Encoding.UTF8.GetBytes(senhaAberta);

            var criptoResult = criptoProvider.ComputeHash(btexto);

            return Convert.ToHexString(criptoResult);
        }
    }
}