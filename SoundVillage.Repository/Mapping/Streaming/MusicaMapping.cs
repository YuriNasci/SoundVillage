using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoundVillage.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoundVillage.Domain.Streaming.ValueObject;

namespace SoundVillage.Repository.Mapping.Streaming
{
    public class MusicaMapping : IEntityTypeConfiguration<Musica>
    {
        public void Configure(EntityTypeBuilder<Musica> builder)
        {
            builder.ToTable(nameof(Musica));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);

            builder.OwnsOne<Duracao>(d => d.Duracao, c =>
            {
                c.Property(x => x.Valor).IsRequired().HasMaxLength(50);
            });


        }
    }
}
