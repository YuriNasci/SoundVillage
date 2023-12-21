using SoundVillage.Domain.Conta;
using SoundVillage.Domain.Streaming.Agreggates;
using SoundVillage.Domain.Streaming.ValueObject;
using SoundVillage.Domain.Transacao.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoudVillage.Tests.Domain
{
    public class ContaStreamingTests
    {
        [Fact]
        public void DeveCriarContaComSucesso()
        {
            // Arrange: Configuração do ambiente de teste
            var nome = "Teste Usuario";
            var email = "teste@usuario.com";
            var senha = "senha123";
            var dataNascimento = new DateTime(1990, 1, 1);

            var contaOrigem = new ContaBancaria("Buier Nouli Makobag", "38971070072");
            var cartao = contaOrigem.SolicitarCartaoCredito();
            cartao.AtivarCartao();

            var contaDestino = new ContaBancaria("Xaevu Cafosa Xeriu", "79004023062");

            var plano = new Plano() {
                ContaBancariaCobradora = contaDestino,
                Descricao = "Basico",
                Nome = "Basico",
                Recorrencia = RecorrenciaPlano.MENSAL,
                Valor = 0
            };

            var contaStreaming = new ContaStreaming();

            // Act: Execução da funcionalidade a ser testada
            contaStreaming.CriarConta(nome, email, senha, dataNascimento, plano, cartao);

            // Assert: Verificação dos resultados esperados
            Assert.Equal(nome, contaStreaming.Nome);
            Assert.Equal(email, contaStreaming.Email);
            Assert.NotEqual(senha, contaStreaming.Senha); // Senha deve ser criptografada
            Assert.Equal(dataNascimento, contaStreaming.DataNascimento);
            Assert.Contains(cartao, contaStreaming.Cartoes);
            Assert.Single(contaStreaming.Assinaturas); // Assume que uma assinatura é criada
            Assert.Single(contaStreaming.Playlists); // Assume que uma playlist é criada
            Assert.Equal("Favoritas", contaStreaming.Playlists[0].Nome); // Nome da playlist padrão
        }

        [Fact]
        public void NaoDeveCriarContaComCartaoSemLimite()
        {
            // Arrange: Configuração do ambiente de teste
            var nome = "Teste Usuario";
            var email = "teste@usuario.com";
            var senha = "senha123";
            var dataNascimento = new DateTime(1990, 1, 1);

            var contaDestino = new ContaBancaria("Xaevu Cafosa Xeriu", "79004023062");

            var plano = new Plano()
            {
                ContaBancariaCobradora = contaDestino,
                Descricao = "Basico",
                Nome = "Basico",
                Recorrencia = RecorrenciaPlano.MENSAL,
                Valor = 50
            };

            // Cartão sem limite
            var cartao = new Cartao(0, "1234567890", new ContaBancaria("Buier Nouli Makobag", "38971070072"));
            cartao.AtivarCartao();

            var contaStreaming = new ContaStreaming();

            // Act & Assert: Execução da funcionalidade e verificação dos resultados
            var exception = Record.Exception(() => contaStreaming.CriarConta(nome, email, senha, dataNascimento, plano, cartao));
            Assert.NotNull(exception);
            Assert.IsType<Exception>(exception);
            Assert.Contains("Cartão não possui limite para esta transacao", exception.Message, StringComparison.OrdinalIgnoreCase);
        }
    }
}
