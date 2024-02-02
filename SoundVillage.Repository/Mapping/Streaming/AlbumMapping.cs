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
    public class AlbumMapping : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Albums");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(a => a.Ano)
                .IsRequired();

            builder.HasMany(a => a.Musica)
                .WithOne() // Aqui você precisa especificar a propriedade de navegação inversa, se houver
                .HasForeignKey("AlbumId"); // Especifique o nome da chave estrangeira aqui, se necessário

            // Outras configurações específicas do mapeamento podem ser adicionadas aqui
        }
    }
}
