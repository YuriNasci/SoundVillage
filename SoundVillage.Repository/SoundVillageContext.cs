﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SoundVillage.Domain.Conta;
using SoundVillage.Domain.Conta.Agreggates;
using SoundVillage.Domain.Notificacao;
using SoundVillage.Domain.Streaming.Aggregates;
using SoundVillage.Domain.Streaming.Agreggates;
using SoundVillage.Domain.Transacao.Aggregates;
using SoundVillage.Domain.Transacao.Agreggates;

namespace SoundVillage.Repository
{
    public class SoundVillageContext: DbContext
    {
        public DbSet<Assinatura> Assinaturas { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Notificacao> Notificacoes { get; set; }
        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<Album> Albuns { get; set; }
        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Plano> Planos { get; set; }
        public DbSet<ContaStreaming> ContaStreaming { get; set; }
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<ContaBancaria> ContasBancarias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public SoundVillageContext(DbContextOptions<SoundVillageContext> options) : base(options)
        {

        }


        //Escrever protected internal e vai aparecer OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SoundVillageContext).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Musica>()
                .HasOne(m => m.Album)
                .WithMany(a => a.Musicas)
                .HasForeignKey(m => m.AlbumId);
            
            DatabaseSeed.Seed(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(x => x.AddConsole()));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
