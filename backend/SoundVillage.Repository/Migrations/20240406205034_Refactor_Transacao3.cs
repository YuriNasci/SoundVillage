using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoundVillage.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Refactor_Transacao3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LimiteDisponivel",
                table: "Cartao",
                newName: "Limite");

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Playlist",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Notificacao",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Cartao",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Assinatura",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DtNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Playlist_UsuarioId",
                table: "Playlist",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacao_UsuarioId",
                table: "Notificacao",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cartao_UsuarioId",
                table: "Cartao",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Assinatura_UsuarioId",
                table: "Assinatura",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assinatura_Usuario_UsuarioId",
                table: "Assinatura",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cartao_Usuario_UsuarioId",
                table: "Cartao",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notificacao_Usuario_UsuarioId",
                table: "Notificacao",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlist_Usuario_UsuarioId",
                table: "Playlist",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assinatura_Usuario_UsuarioId",
                table: "Assinatura");

            migrationBuilder.DropForeignKey(
                name: "FK_Cartao_Usuario_UsuarioId",
                table: "Cartao");

            migrationBuilder.DropForeignKey(
                name: "FK_Notificacao_Usuario_UsuarioId",
                table: "Notificacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Playlist_Usuario_UsuarioId",
                table: "Playlist");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Playlist_UsuarioId",
                table: "Playlist");

            migrationBuilder.DropIndex(
                name: "IX_Notificacao_UsuarioId",
                table: "Notificacao");

            migrationBuilder.DropIndex(
                name: "IX_Cartao_UsuarioId",
                table: "Cartao");

            migrationBuilder.DropIndex(
                name: "IX_Assinatura_UsuarioId",
                table: "Assinatura");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Notificacao");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Cartao");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Assinatura");

            migrationBuilder.RenameColumn(
                name: "Limite",
                table: "Cartao",
                newName: "LimiteDisponivel");
        }
    }
}
