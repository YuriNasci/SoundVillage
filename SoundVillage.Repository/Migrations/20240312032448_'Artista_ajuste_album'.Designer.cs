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
    [Migration("20240312032448_'Artista_ajuste_album'")]
    partial class Artista_ajuste_album
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PlaylistMusica", b =>
                {
                    b.Property<Guid>("MusicaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlaylistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAdicionada")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("MusicaId", "PlaylistId");

                    b.HasIndex("PlaylistId");

                    b.ToTable("PlaylistMusica");
                });

            modelBuilder.Entity("SoundVillage.Domain.Conta.Assinatura", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CartaoPagamentoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ContaStreamingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAtual")
                        .HasColumnType("bit");

                    b.Property<Guid>("PlanoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Validade")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CartaoPagamentoId");

                    b.HasIndex("ContaStreamingId");

                    b.HasIndex("PlanoId");

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

                    b.Property<Guid>("ContaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ContaId");

                    b.ToTable("Playlist", (string)null);
                });

            modelBuilder.Entity("SoundVillage.Domain.Notificacao.Notificacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ContaBancariaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ContaId")
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

                    b.Property<bool>("Visualizada")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ContaBancariaId");

                    b.HasIndex("ContaId");

                    b.ToTable("Notificacao", (string)null);
                });

            modelBuilder.Entity("SoundVillage.Domain.Streaming.Agreggates.Album", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Ano")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("ArtistaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("ArtistaId");

                    b.ToTable("Albums", (string)null);
                });

            modelBuilder.Entity("SoundVillage.Domain.Streaming.Agreggates.Artista", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Backdrop")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Artistas", (string)null);
                });

            modelBuilder.Entity("SoundVillage.Domain.Streaming.Agreggates.Musica", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AlbumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Musicas", (string)null);
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

            modelBuilder.Entity("SoundVillage.Domain.Transacao.Aggregates.Cartao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<Guid>("ContaBancariaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ContaStreamingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContaBancariaId");

                    b.HasIndex("ContaStreamingId");

                    b.ToTable("Cartoes", (string)null);
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

                    b.ToTable("ContasBancarias", (string)null);
                });

            modelBuilder.Entity("SoundVillage.Domain.Transacao.Aggregates.Transacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CartaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ContaDestinoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ContaOrigemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("Horario")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CartaoId");

                    b.HasIndex("ContaDestinoId");

                    b.HasIndex("ContaOrigemId");

                    b.ToTable("Transacoes", (string)null);
                });

            modelBuilder.Entity("PlaylistMusica", b =>
                {
                    b.HasOne("SoundVillage.Domain.Streaming.Agreggates.Musica", null)
                        .WithMany()
                        .HasForeignKey("MusicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoundVillage.Domain.Conta.Playlist", null)
                        .WithMany()
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SoundVillage.Domain.Conta.Assinatura", b =>
                {
                    b.HasOne("SoundVillage.Domain.Transacao.Aggregates.Cartao", "CartaoPagamento")
                        .WithMany()
                        .HasForeignKey("CartaoPagamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoundVillage.Domain.Conta.ContaStreaming", null)
                        .WithMany("Assinaturas")
                        .HasForeignKey("ContaStreamingId");

                    b.HasOne("SoundVillage.Domain.Streaming.Agreggates.Plano", "Plano")
                        .WithMany()
                        .HasForeignKey("PlanoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CartaoPagamento");

                    b.Navigation("Plano");
                });

            modelBuilder.Entity("SoundVillage.Domain.Conta.Playlist", b =>
                {
                    b.HasOne("SoundVillage.Domain.Conta.ContaStreaming", "Conta")
                        .WithMany("Playlists")
                        .HasForeignKey("ContaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conta");
                });

            modelBuilder.Entity("SoundVillage.Domain.Notificacao.Notificacao", b =>
                {
                    b.HasOne("SoundVillage.Domain.Transacao.Aggregates.ContaBancaria", null)
                        .WithMany("Notificacoes")
                        .HasForeignKey("ContaBancariaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SoundVillage.Domain.Transacao.Aggregates.ContaBancaria", "Conta")
                        .WithMany()
                        .HasForeignKey("ContaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conta");
                });

            modelBuilder.Entity("SoundVillage.Domain.Streaming.Agreggates.Album", b =>
                {
                    b.HasOne("SoundVillage.Domain.Streaming.Agreggates.Artista", null)
                        .WithMany("Discografia")
                        .HasForeignKey("ArtistaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SoundVillage.Domain.Streaming.Agreggates.Musica", b =>
                {
                    b.HasOne("SoundVillage.Domain.Streaming.Agreggates.Album", null)
                        .WithMany("Musica")
                        .HasForeignKey("AlbumId");

                    b.OwnsOne("SoundVillage.Domain.Streaming.ValueObject.Duracao", "Duracao", b1 =>
                        {
                            b1.Property<Guid>("MusicaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Valor")
                                .HasMaxLength(50)
                                .HasColumnType("int");

                            b1.HasKey("MusicaId");

                            b1.ToTable("Musicas");

                            b1.WithOwner()
                                .HasForeignKey("MusicaId");
                        });

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

            modelBuilder.Entity("SoundVillage.Domain.Transacao.Aggregates.Cartao", b =>
                {
                    b.HasOne("SoundVillage.Domain.Transacao.Aggregates.ContaBancaria", "Conta")
                        .WithMany()
                        .HasForeignKey("ContaBancariaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoundVillage.Domain.Conta.ContaStreaming", null)
                        .WithMany("Cartoes")
                        .HasForeignKey("ContaStreamingId");

                    b.OwnsOne("SoundVillage.Domain.Core.ValueObjects.Monetario", "LimiteDisponivel", b1 =>
                        {
                            b1.Property<Guid>("CartaoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Valor")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("LimiteDisponivel");

                            b1.HasKey("CartaoId");

                            b1.ToTable("Cartoes");

                            b1.WithOwner()
                                .HasForeignKey("CartaoId");
                        });

                    b.Navigation("Conta");

                    b.Navigation("LimiteDisponivel")
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

                            b1.ToTable("ContasBancarias");

                            b1.WithOwner()
                                .HasForeignKey("ContaBancariaId");
                        });

                    b.Navigation("Saldo")
                        .IsRequired();
                });

            modelBuilder.Entity("SoundVillage.Domain.Transacao.Aggregates.Transacao", b =>
                {
                    b.HasOne("SoundVillage.Domain.Transacao.Aggregates.Cartao", null)
                        .WithMany("Transacoes")
                        .HasForeignKey("CartaoId");

                    b.HasOne("SoundVillage.Domain.Transacao.Aggregates.ContaBancaria", "ContaDestino")
                        .WithMany()
                        .HasForeignKey("ContaDestinoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SoundVillage.Domain.Transacao.Aggregates.ContaBancaria", "ContaOrigem")
                        .WithMany()
                        .HasForeignKey("ContaOrigemId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.OwnsOne("SoundVillage.Domain.Core.ValueObjects.Monetario", "Valor", b1 =>
                        {
                            b1.Property<Guid>("TransacaoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Valor")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Valor");

                            b1.HasKey("TransacaoId");

                            b1.ToTable("Transacoes");

                            b1.WithOwner()
                                .HasForeignKey("TransacaoId");
                        });

                    b.Navigation("ContaDestino");

                    b.Navigation("ContaOrigem");

                    b.Navigation("Valor")
                        .IsRequired();
                });

            modelBuilder.Entity("SoundVillage.Domain.Conta.ContaStreaming", b =>
                {
                    b.Navigation("Assinaturas");

                    b.Navigation("Cartoes");

                    b.Navigation("Playlists");
                });

            modelBuilder.Entity("SoundVillage.Domain.Streaming.Agreggates.Album", b =>
                {
                    b.Navigation("Musica");
                });

            modelBuilder.Entity("SoundVillage.Domain.Streaming.Agreggates.Artista", b =>
                {
                    b.Navigation("Discografia");
                });

            modelBuilder.Entity("SoundVillage.Domain.Transacao.Aggregates.Cartao", b =>
                {
                    b.Navigation("Transacoes");
                });

            modelBuilder.Entity("SoundVillage.Domain.Transacao.Aggregates.ContaBancaria", b =>
                {
                    b.Navigation("Notificacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
