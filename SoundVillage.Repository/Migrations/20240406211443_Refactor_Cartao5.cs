using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoundVillage.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Refactor_Cartao5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cartao_ContaBancaria_ContaBancariaId",
                table: "Cartao");

            migrationBuilder.DropIndex(
                name: "IX_Cartao_ContaBancariaId",
                table: "Cartao");

            migrationBuilder.DropColumn(
                name: "ContaBancariaId",
                table: "Cartao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ContaBancariaId",
                table: "Cartao",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cartao_ContaBancariaId",
                table: "Cartao",
                column: "ContaBancariaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cartao_ContaBancaria_ContaBancariaId",
                table: "Cartao",
                column: "ContaBancariaId",
                principalTable: "ContaBancaria",
                principalColumn: "Id");
        }
    }
}
