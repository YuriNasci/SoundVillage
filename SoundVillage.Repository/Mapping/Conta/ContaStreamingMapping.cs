using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoundVillage.Domain.Conta;

namespace SoundVillage.Repository.Mapping.Conta
{
    public class ContaStreamingMapping : IEntityTypeConfiguration<ContaStreaming>
    {
        public void Configure(EntityTypeBuilder<ContaStreaming> builder)
        {
            builder.ToTable(nameof(ContaStreaming));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DataNascimento).IsRequired();

            //builder.HasMany(x => x.Cartoes).WithOne();
            //builder.HasMany(x => x.Assinaturas).WithOne();
            //builder.HasMany(x => x.Playlists).WithOne(x => x.Conta);
        }
    }
}
