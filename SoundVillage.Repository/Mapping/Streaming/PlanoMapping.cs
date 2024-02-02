using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SoundVillage.Domain.Streaming.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Repository.Mapping.Streaming
{
    public class PlanoMapping : IEntityTypeConfiguration<Plano>
    {
        public void Configure(EntityTypeBuilder<Plano> builder)
        {
            builder.ToTable("Planos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.Descricao)
                .HasMaxLength(500); // Ajuste conforme a necessidade

            // Mapeamento do Value Object Monetario
            builder.OwnsOne(p => p.Valor, valor =>
            {
                valor.Property(v => v.Valor).HasColumnName("Valor");
                // Outras propriedades de Monetario, se houver, podem ser mapeadas aqui
            });

            // Mapeamento do enum RecorrenciaPlano
            builder.Property(p => p.Recorrencia)
                .IsRequired()
                .HasConversion<int>() // Converte o enum para int ao salvar no banco de dados
                .HasColumnName("Recorrencia");

            // Mapeamento da entidade ContaBancariaCobradora
            // Supondo que ContaBancaria seja outra entidade com seu próprio mapeamento
            builder.HasOne(p => p.ContaBancariaCobradora)
                .WithMany()
                .HasForeignKey("ContaBancariaId"); // Ajuste o nome da chave estrangeira conforme necessário

            // Outras configurações específicas do mapeamento podem ser adicionadas aqui
        }
    }
}
