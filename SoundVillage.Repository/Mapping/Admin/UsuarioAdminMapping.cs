using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoundVillage.Domain.Admin.Aggregates;
using SoundVillage.Domain.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Repository.Mapping.Admin
{
    public class UsuarioAdminMapping : IEntityTypeConfiguration<UsuarioAdmin>
    {
        public void Configure(EntityTypeBuilder<UsuarioAdmin> builder)
        {
            builder.ToTable(nameof(UsuarioAdmin));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Perfil).IsRequired();
        }
    }
}
