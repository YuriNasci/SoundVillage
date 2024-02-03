using SoundVillage.Domain.Core.ValueObjects;
using SoundVillage.Domain.Notificacao;
using SoundVillage.Domain.Transacao.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoudVillage.Tests.Domain
{
    public class CartaoTests
    {
        [Fact]
        public void DeveCriarTransacaoComSucesso()
        {
            // Arrange: Configuração do ambiente de teste
            var contaOrigem = new ContaBancaria("Buier Nouli Makobag", "38971070072");
            var cartao = contaOrigem.SolicitarCartaoCredito();
            cartao.AtivarCartao();

            var contaDestino = new ContaBancaria("Xaevu Cafosa Xeriu", "79004023062");

            var valorTransacao = cartao.LimiteDisponivel / 2;
            var limiteCartao = cartao.GetLimiteDisponivel();
            var limiteCartaoEsperado = limiteCartao - valorTransacao;

            // Act: Execução da funcionalidade a ser testada
            cartao.CriarTransacao(contaDestino, valorTransacao);

            // Assert: Verificação dos resultados esperados
            Assert.True(cartao.GetTransacoes().Count > 0);
            Assert.True(cartao.GetLimiteDisponivel() == limiteCartaoEsperado);
        }

        [Fact]
        public void NaoDeveCriarTransacaoComCartaoSemLimite()
        {
            // Arrange: Configuração do ambiente de teste
            var contaOrigem = new ContaBancaria("Buier Nouli Makobag", "38971070072");
            var cartao = contaOrigem.SolicitarCartaoCredito();
            cartao.AtivarCartao();

            var contaDestino = new ContaBancaria("Xaevu Cafosa Xeriu", "79004023062");

            var valorTransacao = cartao.LimiteDisponivel + 1;

            // Act & Assert: Execução da funcionalidade e verificação dos resultados
            Assert.Throws<System.Exception>(
                () => cartao.CriarTransacao(contaDestino, valorTransacao));
        }

        [Fact]
        public void NaoDeveCriarTransacaoComCartaoValorDuplicado()
        {
            // Arrange: Configuração do ambiente de teste
            var contaOrigem = new ContaBancaria("Buier Nouli Makobag", "38971070072");
            var cartao = contaOrigem.SolicitarCartaoCredito();
            cartao.AtivarCartao();

            var contaDestino = new ContaBancaria("Xaevu Cafosa Xeriu", "79004023062");

            var valorTransacao = cartao.LimiteDisponivel / 2;

            cartao.CriarTransacao(contaDestino, valorTransacao); // Primeira transação

            // Act & Assert: Execução da funcionalidade e verificação dos resultados
            Assert.Throws<System.Exception>(
                () => cartao.CriarTransacao(contaDestino, valorTransacao));
        }

        [Fact]
        public void NaoDeveCriarTransacaoComCartaoAltoFrequencia()
        {
            // Arrange: Configuração do ambiente de teste
            var contaOrigem = new ContaBancaria("Buier Nouli Makobag", "38971070072");
            var cartao = contaOrigem.SolicitarCartaoCredito();
            cartao.AtivarCartao();

            var contaDestino = new ContaBancaria("Xaevu Cafosa Xeriu", "79004023062");

            var random = new Random();

            // Criando três transações em rápida sucessão com valores aleatórios
            for (int i = 0; i < 3; i++)
            {
                var valorTransacao = random.Next(1, (int)cartao.LimiteDisponivel); // Valor aleatório menor que o limite
                cartao.CriarTransacao(contaDestino , valorTransacao, (i + 1).ToString());
                Thread.Sleep(1000); // Pausa de 1 segundo para simular intervalo entre transações
            }

            // Act & Assert: Execução da funcionalidade e verificação dos resultados
            Assert.Throws<System.Exception>(
                () => cartao.CriarTransacao(contaDestino, cartao.LimiteDisponivel / 2));
        }

        [Fact]
        public void NaoDeveCriarTransacaoComCartaoInativo()
        {
            // Arrange: Configuração do ambiente de teste
            var contaOrigem = new ContaBancaria("Buier Nouli Makobag", "38971070072");
            var cartao = contaOrigem.SolicitarCartaoCredito();

            var contaDestino = new ContaBancaria("Xaevu Cafosa Xeriu", "79004023062");

            var valorTransacao = cartao.LimiteDisponivel / 2;

            // Act & Assert: Execução da funcionalidade e verificação dos resultados
            Assert.Throws<System.Exception>(
                () => cartao.CriarTransacao(contaDestino, valorTransacao));
        }

        [Fact]
        public void DeveCriarNotificacoesApropriadasAposTransacao()
        {
            // Arrange
            var contaOrigem = new ContaBancaria("Buier Nouli Makobag", "38971070072");
            var contaDestino = new ContaBancaria("Xaevu Cafosa Xeriu", "79004023062");
            var cartao = new Cartao(1000, "1234567890", contaOrigem);
            cartao.AtivarCartao();
            var valorTransacao = new Monetario(100);

            // Act
            cartao.CriarTransacao(contaDestino, valorTransacao);

            // Assert
            // Verifique se as notificações foram criadas corretamente
            Assert.Contains(contaOrigem.Notificacoes, n => n.Conta == contaOrigem && n.Mensagem.Contains("Pagamento de"));
            Assert.Contains(contaDestino.Notificacoes, n => n.Conta == contaDestino && n.Mensagem.Contains("Recebimento de"));
        }
    }
}
