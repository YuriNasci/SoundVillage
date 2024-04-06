using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoundVillage.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Refactor_Playlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlist_ContaStreaming_ContaId",
                table: "Playlist");

            migrationBuilder.DropIndex(
                name: "IX_Playlist_ContaId",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "ContaId",
                table: "Playlist");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ContaId",
                table: "Playlist",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Playlist_ContaId",
                table: "Playlist",
                column: "ContaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlist_ContaStreaming_ContaId",
                table: "Playlist",
                column: "ContaId",
                principalTable: "ContaStreaming",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
