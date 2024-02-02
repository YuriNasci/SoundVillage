using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SoundVillage.Domain.Streaming.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoundVillage.Domain.Conta;
using SoundVillage.Domain.Streaming.ValueObject;

namespace SoundVillage.Repository.Mapping.Streaming
{
    public class MusicaMapping : IEntityTypeConfiguration<Musica>
    {
        public void Configure(EntityTypeBuilder<Musica> builder)
        {
            builder.ToTable("Musicas");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Nome)
                .IsRequired()
                .HasMaxLength(255);

            // Mapeamento do Value Object Duracao
            builder.OwnsOne<Duracao>(d => d.Duracao, c =>
            {
                c.Property(x => x.Valor).IsRequired().HasMaxLength(50);
            });

            builder.HasMany(m => m.Playlists)
                .WithMany(p => p.Musicas)
                .UsingEntity<Dictionary<string, object>>(
                    "PlaylistMusica", // Nome da tabela de junção
                    j => j.HasOne<Playlist>().WithMany().HasForeignKey("PlaylistId"),
                    j => j.HasOne<Musica>().WithMany().HasForeignKey("MusicaId"),
                    j =>
                    {
                        j.Property<DateTime>("DataAdicionada").HasDefaultValueSql("CURRENT_TIMESTAMP");
                        // Outras propriedades da tabela de junção, se houver
                    });

            // Outras configurações específicas do mapeamento podem ser adicionadas aqui
        }
    }
}
