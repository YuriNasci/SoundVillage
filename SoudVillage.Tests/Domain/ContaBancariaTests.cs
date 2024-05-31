using Xunit;
using SoundVillage.Domain.Transacao.Aggregates;
using System;

namespace SoundVillage.Tests.Domain
{
    public class ContaBancariaTests
    {
        [Fact]
        public void DeveCriarCartaoDeCreditoValido()
        {
            // Arrange
            var conta = new ContaBancaria("Nome do Usuário", "123.456.789-00");

            // Act
            var cartao = conta.SolicitarCartaoCredito();

            // Assert
            Assert.NotNull(cartao); // Verifica se um cartão foi criado
        }
    }
}
