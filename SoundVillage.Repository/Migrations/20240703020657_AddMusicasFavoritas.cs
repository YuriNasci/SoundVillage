using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoundVillage.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddMusicasFavoritas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MusicaFavorita",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MusicaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicaFavorita", x => new { x.UsuarioId, x.MusicaId });
                    table.ForeignKey(
                        name: "FK_MusicaFavorita_Musica_MusicaId",
                        column: x => x.MusicaId,
                        principalTable: "Musica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusicaFavorita_MusicaId",
                table: "MusicaFavorita",
                column: "MusicaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusicaFavorita");
        }
    }
}
