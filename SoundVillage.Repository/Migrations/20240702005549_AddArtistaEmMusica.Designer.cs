﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoundVillage.Repository;

#nullable disable

namespace SoundVillage.Repository.Migrations
{
    [DbContext(typeof(SoundVillageContext))]
    [Migration("20240702005549_AddArtistaEmMusica")]
    partial class AddArtistaEmMusica
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MusicaPlaylist", b =>
                {
                    b.Property<Guid>("MusicasId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlaylistsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MusicasId", "PlaylistsId");

                    b.HasIndex("PlaylistsId");

                    b.ToTable("MusicaPlaylist");
                });

            modelBuilder.Entity("SoundVillage.Domain.Admin.Aggregates.UsuarioAdmin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Perfil")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UsuarioAdmin", (string)null);
                });

            modelBuilder.Entity("SoundVillage.Domain.Conta.Agreggates.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DtNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("SoundVillage.Domain.Conta.Assinatura", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAtual")
                        .HasColumnType("bit");

                    b.Property<Guid>("PlanoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Validade")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PlanoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Assinatura", (string)null);
                });

            modelBuilder.Entity("SoundVillage.Domain.Conta.ContaStreaming", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("ContaStreaming", (string)null);
                });

            modelBuilder.Entity("SoundVillage.Domain.Conta.Playlist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Playlist", (string)null);
                });

            modelBuilder.Entity("SoundVillage.Domain.Notificacao.Notificacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ContaBancariaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataNotificacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<Guid?>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Visualizada")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ContaBancariaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Notificacao", (string)null);
                });

            modelBuilder.Entity("SoundVillage.Domain.Streaming.Aggregates.Album", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ArtistaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ArtistaId");

                    b.ToTable("Album", (string)null);
                });

            modelBuilder.Entity("SoundVillage.Domain.Streaming.Aggregates.Artista", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Backdrop")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Artista", (string)null);
                });

            modelBuilder.Entity("SoundVillage.Domain.Streaming.Aggregates.Musica", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AlbumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ArtistaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("ArtistaId");

                    b.ToTable("Musica", (string)null);
                });

            modelBuilder.Entity("SoundVillage.Domain.Streaming.Agreggates.Plano", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ContaBancariaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Recorrencia")
                        .HasColumnType("int")
                        .HasColumnName("Recorrencia");

                    b.HasKey("Id");

                    b.HasIndex("ContaBancariaId");

                    b.ToTable("Planos", (string)null);
                });

            modelBuilder.Entity("SoundVillage.Domain.Transacao.Aggregates.ContaBancaria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Digito")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroAgencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroConta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContaBancaria", (string)null);
                });

            modelBuilder.Entity("SoundVillage.Domain.Transacao.Agreggates.Cartao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Cartao", (string)null);
                });

            modelBuilder.Entity("SoundVillage.Domain.Transacao.Agreggates.Transacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CartaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DtTransacao")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CartaoId");

                    b.ToTable("Transacao", (string)null);
                });

            modelBuilder.Entity("MusicaPlaylist", b =>
                {
                    b.HasOne("SoundVillage.Domain.Streaming.Aggregates.Musica", null)
                        .WithMany()
                        .HasForeignKey("MusicasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoundVillage.Domain.Conta.Playlist", null)
                        .WithMany()
                        .HasForeignKey("PlaylistsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SoundVillage.Domain.Conta.Assinatura", b =>
                {
                    b.HasOne("SoundVillage.Domain.Streaming.Agreggates.Plano", "Plano")
                        .WithMany()
                        .HasForeignKey("PlanoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoundVillage.Domain.Conta.Agreggates.Usuario", null)
                        .WithMany("Assinaturas")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Plano");
                });

            modelBuilder.Entity("SoundVillage.Domain.Conta.Playlist", b =>
                {
                    b.HasOne("SoundVillage.Domain.Conta.Agreggates.Usuario", "Usuario")
                        .WithMany("Playlists")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SoundVillage.Domain.Notificacao.Notificacao", b =>
                {
                    b.HasOne("SoundVillage.Domain.Transacao.Aggregates.ContaBancaria", "ContaBancaria")
                        .WithMany("Notificacoes")
                        .HasForeignKey("ContaBancariaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoundVillage.Domain.Conta.Agreggates.Usuario", null)
                        .WithMany("Notificacoes")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("ContaBancaria");
                });

            modelBuilder.Entity("SoundVillage.Domain.Streaming.Aggregates.Album", b =>
                {
                    b.HasOne("SoundVillage.Domain.Streaming.Aggregates.Artista", null)
                        .WithMany("Albums")
                        .HasForeignKey("ArtistaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SoundVillage.Domain.Streaming.Aggregates.Musica", b =>
                {
                    b.HasOne("SoundVillage.Domain.Streaming.Aggregates.Album", "Album")
                        .WithMany("Musicas")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoundVillage.Domain.Streaming.Aggregates.Artista", "Artista")
                        .WithMany()
                        .HasForeignKey("ArtistaId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.OwnsOne("SoundVillage.Domain.Streaming.ValueObject.Duracao", "Duracao", b1 =>
                        {
                            b1.Property<Guid>("MusicaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Valor")
                                .HasMaxLength(50)
                                .HasColumnType("int");

                            b1.HasKey("MusicaId");

                            b1.ToTable("Musica");

                            b1.WithOwner()
                                .HasForeignKey("MusicaId");
                        });

                    b.Navigation("Album");

                    b.Navigation("Artista");

                    b.Navigation("Duracao")
                        .IsRequired();
                });

            modelBuilder.Entity("SoundVillage.Domain.Streaming.Agreggates.Plano", b =>
                {
                    b.HasOne("SoundVillage.Domain.Transacao.Aggregates.ContaBancaria", "ContaBancariaCobradora")
                        .WithMany()
                        .HasForeignKey("ContaBancariaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("SoundVillage.Domain.Core.ValueObjects.Monetario", "Valor", b1 =>
                        {
                            b1.Property<Guid>("PlanoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Valor")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Valor");

                            b1.HasKey("PlanoId");

                            b1.ToTable("Planos");

                            b1.WithOwner()
                                .HasForeignKey("PlanoId");
                        });

                    b.Navigation("ContaBancariaCobradora");

                    b.Navigation("Valor")
                        .IsRequired();
                });

            modelBuilder.Entity("SoundVillage.Domain.Transacao.Aggregates.ContaBancaria", b =>
                {
                    b.OwnsOne("SoundVillage.Domain.Core.ValueObjects.Monetario", "Saldo", b1 =>
                        {
                            b1.Property<Guid>("ContaBancariaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Valor")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Saldo");

                            b1.HasKey("ContaBancariaId");

                            b1.ToTable("ContaBancaria");

                            b1.WithOwner()
                                .HasForeignKey("ContaBancariaId");
                        });

                    b.Navigation("Saldo")
                        .IsRequired();
                });

            modelBuilder.Entity("SoundVillage.Domain.Transacao.Agreggates.Cartao", b =>
                {
                    b.HasOne("SoundVillage.Domain.Conta.Agreggates.Usuario", null)
                        .WithMany("Cartoes")
                        .HasForeignKey("UsuarioId");

                    b.OwnsOne("SoundVillage.Domain.Core.ValueObjects.Monetario", "Limite", b1 =>
                        {
                            b1.Property<Guid>("CartaoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Valor")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Limite");

                            b1.HasKey("CartaoId");

                            b1.ToTable("Cartao");

                            b1.WithOwner()
                                .HasForeignKey("CartaoId");
                        });

                    b.Navigation("Limite")
                        .IsRequired();
                });

            modelBuilder.Entity("SoundVillage.Domain.Transacao.Agreggates.Transacao", b =>
                {
                    b.HasOne("SoundVillage.Domain.Transacao.Agreggates.Cartao", null)
                        .WithMany("Transacoes")
                        .HasForeignKey("CartaoId");

                    b.OwnsOne("SoundVillage.Domain.Core.ValueObjects.Monetario", "Valor", b1 =>
                        {
                            b1.Property<Guid>("TransacaoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Valor")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("ValorTransacao");

                            b1.HasKey("TransacaoId");

                            b1.ToTable("Transacao");

                            b1.WithOwner()
                                .HasForeignKey("TransacaoId");
                        });

                    b.OwnsOne("SoundVillage.Domain.Transacao.ValueObject.Merchant", "Merchant", b1 =>
                        {
                            b1.Property<Guid>("TransacaoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Nome")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("MerchantNome");

                            b1.HasKey("TransacaoId");

                            b1.ToTable("Transacao");

                            b1.WithOwner()
                                .HasForeignKey("TransacaoId");
                        });

                    b.Navigation("Merchant")
                        .IsRequired();

                    b.Navigation("Valor")
                        .IsRequired();
                });

            modelBuilder.Entity("SoundVillage.Domain.Conta.Agreggates.Usuario", b =>
                {
                    b.Navigation("Assinaturas");

                    b.Navigation("Cartoes");

                    b.Navigation("Notificacoes");

                    b.Navigation("Playlists");
                });

            modelBuilder.Entity("SoundVillage.Domain.Streaming.Aggregates.Album", b =>
                {
                    b.Navigation("Musicas");
                });

            modelBuilder.Entity("SoundVillage.Domain.Streaming.Aggregates.Artista", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("SoundVillage.Domain.Transacao.Aggregates.ContaBancaria", b =>
                {
                    b.Navigation("Notificacoes");
                });

            modelBuilder.Entity("SoundVillage.Domain.Transacao.Agreggates.Cartao", b =>
                {
                    b.Navigation("Transacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
