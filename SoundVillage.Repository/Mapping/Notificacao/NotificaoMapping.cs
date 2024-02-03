using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Repository.Mapping.Notificacao
{
    public class NotificaoMapping : IEntityTypeConfiguration<SoundVillage.Domain.Notificacao.Notificacao>
    {
        public void Configure(EntityTypeBuilder<Domain.Notificacao.Notificacao> builder)
        {
            builder.ToTable(nameof(Domain.Notificacao.Notificacao));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Mensagem).IsRequired().HasMaxLength(250);
            builder.Property(x => x.DataNotificacao).IsRequired();
            builder.Property(x => x.Visualizada).IsRequired();

            builder.HasOne(x => x.Conta).WithMany(x => x.Notificacoes).IsRequired().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
