using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoundVillage.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Refactor_Cartao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cartoes_ContasBancarias_ContaBancariaId",
                table: "Cartoes");

            migrationBuilder.AddColumn<Guid>(
                name: "ContaId",
                table: "Cartoes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Cartoes_ContaId",
                table: "Cartoes",
                column: "ContaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cartoes_ContasBancarias_ContaBancariaId",
                table: "Cartoes",
                column: "ContaBancariaId",
                principalTable: "ContasBancarias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cartoes_ContasBancarias_ContaId",
                table: "Cartoes",
                column: "ContaId",
                principalTable: "ContasBancarias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cartoes_ContasBancarias_ContaBancariaId",
                table: "Cartoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Cartoes_ContasBancarias_ContaId",
                table: "Cartoes");

            migrationBuilder.DropIndex(
                name: "IX_Cartoes_ContaId",
                table: "Cartoes");

            migrationBuilder.DropColumn(
                name: "ContaId",
                table: "Cartoes");

            migrationBuilder.AddForeignKey(
                name: "FK_Cartoes_ContasBancarias_ContaBancariaId",
                table: "Cartoes",
                column: "ContaBancariaId",
                principalTable: "ContasBancarias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
