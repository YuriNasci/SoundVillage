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
    public class CartaoMapping : IEntityTypeConfiguration<Cartao>
    {
        public void Configure(EntityTypeBuilder<Cartao> builder)
        {
            builder.ToTable("Cartoes");

            builder.HasKey(c => c.Id);

            // Mapeamento do Value Object Monetario para LimiteDisponivel
            builder.OwnsOne(c => c.LimiteDisponivel, limite =>
            {
                limite.Property(l => l.Valor).HasColumnName("LimiteDisponivel");
                // Outras propriedades de Monetario, se houver, podem ser mapeadas aqui
            });

            builder.Property<string>("Numero")
                .IsRequired();

            builder.HasOne(c => c.Conta)
                .WithMany()
                .HasForeignKey("ContaBancariaId"); // Ajuste conforme a sua estrutura de banco de dados

            // Mapeamento da lista de Transacoes
            // Assumindo que Transacao é uma entidade com seu próprio mapeamento
            builder.HasMany(c => c.Transacoes)
                .WithOne() // Aqui você precisa especificar a propriedade de navegação inversa em Transacao, se houver
                .HasForeignKey("CartaoId"); // Ajuste conforme a sua estrutura de banco de dados

            // O mapeamento de outras propriedades e configurações específicas podem ser adicionadas aqui
        }
    }
}
