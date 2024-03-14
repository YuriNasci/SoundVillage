using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SoundVillage.Domain.Transacao.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Repository.Mapping.Transacao
{
    public class ContaBancariaMapping : IEntityTypeConfiguration<ContaBancaria>
    {
        public void Configure(EntityTypeBuilder<ContaBancaria> builder)
        {
            builder.ToTable("ContasBancarias");

            builder.HasKey(c => c.Id);

            // Mapeamento do Value Object Monetario para Saldo
            builder.OwnsOne(c => c.Saldo, saldo =>
            {
                saldo.Property(s => s.Valor).HasColumnName("Saldo");
                // Outras propriedades de Monetario, se houver, podem ser mapeadas aqui
            });

            builder.Property<string>("Nome")
                .IsRequired();

            builder.Property<string>("NumeroAgencia")
                .IsRequired();

            builder.Property<string>("NumeroConta")
                .IsRequired();

            builder.Property<string>("Digito")
                .IsRequired();

            builder.Property<string>("Cpf")
                .IsRequired();

            builder.HasMany(c => c.Notificacoes)
                .WithOne() // Especifique a propriedade de navegação inversa em Notificacao, se houver
                .HasForeignKey("ContaBancariaId"); // Ajuste conforme a sua estrutura de banco de dados

            // O mapeamento de outras propriedades e configurações específicas podem ser adicionadas aqui
        }
    }
}
