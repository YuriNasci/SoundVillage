using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SoundVillage.Domain.Admin.Aggregates;
using SoundVillage.Domain.Conta;
using SoundVillage.Domain.Conta.Agreggates;
using SoundVillage.Domain.Notificacao;
using SoundVillage.Domain.Streaming.Aggregates;
using SoundVillage.Domain.Streaming.Agreggates;
using SoundVillage.Domain.Transacao.Aggregates;
using SoundVillage.Domain.Transacao.Agreggates;
using SoundVillage.Repository.Mapping.Admin;

namespace SoundVillage.Repository
{
    public class SoundVillageAdminContext: DbContext
    {
        public DbSet<UsuarioAdmin> UsuarioAdmins { get; set; }
        public SoundVillageAdminContext(DbContextOptions<SoundVillageAdminContext> options) : base(options)
        {

        }

        //Escrever protected internal e vai aparecer OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioAdminMapping());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(x => x.AddConsole()));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
