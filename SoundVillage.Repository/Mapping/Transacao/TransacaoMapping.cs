using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Repository.Mapping.Transacao
{
    public class TransacaoMapping : IEntityTypeConfiguration<Domain.Transacao.Aggregates.Transacao>
    {
        public void Configure(EntityTypeBuilder<Domain.Transacao.Aggregates.Transacao> builder)
        {
            builder.ToTable("Transacoes");

            builder.HasKey(t => t.Id);

            // Mapeamento do Value Object Monetario para Valor
            builder.OwnsOne(t => t.Valor, valor =>
            {
                valor.Property(v => v.Valor).HasColumnName("Valor");
                // Outras propriedades de Monetario, se houver, podem ser mapeadas aqui
            });

            builder.Property(t => t.Horario)
                .IsRequired();

            // Mapeamento das propriedades de navegação para ContaBancaria
            builder.HasOne(t => t.ContaOrigem)
                .WithMany()
                .HasForeignKey("ContaOrigemId"); // Ajuste conforme a sua estrutura de banco de dados

            builder.HasOne(t => t.ContaDestino)
                .WithMany()
                .HasForeignKey("ContaDestinoId"); // Ajuste conforme a sua estrutura de banco de dados

            builder.Property(t => t.Descricao)
                .HasMaxLength(500); // Ajuste conforme a necessidade

            // Outras configurações específicas do mapeamento podem ser adicionadas aqui
        }
    }
}
