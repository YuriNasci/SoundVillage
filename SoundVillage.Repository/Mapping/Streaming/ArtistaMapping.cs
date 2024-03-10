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
    public class ArtistaMapping : IEntityTypeConfiguration<Artista>
    {
        public void Configure(EntityTypeBuilder<Artista> builder)
        {
            builder.ToTable("Artistas");

            builder.HasKey(a => a.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(a => a.Descricao)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(a => a.Backdrop)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(a => a.Discografia)
                .WithOne() // Especifique a propriedade de navegação inversa na classe Album, se houver
                .HasForeignKey("ArtistaId"); // Especifique o nome da chave estrangeira na tabela de álbuns, se necessário

            // Outras configurações específicas do mapeamento podem ser adicionadas aqui
        }
    }
}
