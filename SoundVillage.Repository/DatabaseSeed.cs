using SoundVillage.Domain.Streaming.Agreggates;
using SoundVillage.Domain.Transacao.Aggregates;
using SoundVillage.Domain.Streaming.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace SoundVillage.Repository
{
    public static class DatabaseSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            SeedPlanos(modelBuilder);
        }

        private static void SeedPlanos(ModelBuilder modelBuilder)
        {
            var contaBancariaCobradoraId = Guid.NewGuid();

            modelBuilder.Entity<ContaBancaria>().HasData(
                new
                {
                    Id = contaBancariaCobradoraId,
                    Nome = "Conta Cobradora",
                    Cpf = "11122233344",
                    NumeroAgencia = "9876",
                    NumeroConta = "54321",
                    Digito = "9"
                }
            );

            modelBuilder.Entity<ContaBancaria>().OwnsOne(c => c.Saldo).HasData(
                new { ContaBancariaId = contaBancariaCobradoraId, Valor = 0m }
            );

            var planoBasicoId = Guid.NewGuid();
            var planoPremiumId = Guid.NewGuid();

            modelBuilder.Entity<Plano>().HasData(
                new
                {
                    Id = planoBasicoId,
                    Nome = "Plano Básico",
                    Descricao = "Plano com funcionalidades básicas",
                    Recorrencia = RecorrenciaPlano.MENSAL,
                    ContaBancariaId = contaBancariaCobradoraId
                },
                new
                {
                    Id = planoPremiumId,
                    Nome = "Plano Premium",
                    Descricao = "Plano com todas as funcionalidades",
                    Recorrencia = RecorrenciaPlano.ANUAL,
                    ContaBancariaId = contaBancariaCobradoraId
                }
            );

            modelBuilder.Entity<Plano>().OwnsOne(p => p.Valor).HasData(
                new { PlanoId = planoBasicoId, Valor = 9.99m },
                new { PlanoId = planoPremiumId, Valor = 19.99m }
            );
        }
    }
}