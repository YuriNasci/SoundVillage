using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoundVillage.Domain.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Repository.Mapping.Conta
{
    public class AssinaturaMapping : IEntityTypeConfiguration<Assinatura>
    {
        public void Configure(EntityTypeBuilder<Assinatura> builder)
        {
            builder.ToTable(nameof(Assinatura));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.IsAtual).IsRequired();
            builder.Property(x => x.Validade).IsRequired();

            builder.HasOne(x => x.Plano).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.CartaoPagamento).WithMany(); 
        }
    }
}
