using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoundVillage.Domain.Streaming.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Repository.Mapping.Streaming
{
    public class MusicaFavoritaMapping : IEntityTypeConfiguration<MusicaFavorita>
    {
        public void Configure(EntityTypeBuilder<MusicaFavorita> builder)
        {
            builder.HasKey(e => new { e.UsuarioId, e.MusicaId });
        }
    }
}
