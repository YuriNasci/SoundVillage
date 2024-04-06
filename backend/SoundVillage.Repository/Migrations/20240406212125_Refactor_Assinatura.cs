using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoundVillage.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Refactor_Assinatura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assinatura_Cartao_CartaoPagamentoId",
                table: "Assinatura");

            migrationBuilder.DropForeignKey(
                name: "FK_Assinatura_Planos_PlanoId",
                table: "Assinatura");

            migrationBuilder.DropIndex(
                name: "IX_Assinatura_CartaoPagamentoId",
                table: "Assinatura");

            migrationBuilder.DropColumn(
                name: "CartaoPagamentoId",
                table: "Assinatura");

            migrationBuilder.AddForeignKey(
                name: "FK_Assinatura_Planos_PlanoId",
                table: "Assinatura",
                column: "PlanoId",
                principalTable: "Planos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assinatura_Planos_PlanoId",
                table: "Assinatura");

            migrationBuilder.AddColumn<Guid>(
                name: "CartaoPagamentoId",
                table: "Assinatura",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Assinatura_CartaoPagamentoId",
                table: "Assinatura",
                column: "CartaoPagamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assinatura_Cartao_CartaoPagamentoId",
                table: "Assinatura",
                column: "CartaoPagamentoId",
                principalTable: "Cartao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assinatura_Planos_PlanoId",
                table: "Assinatura",
                column: "PlanoId",
                principalTable: "Planos",
                principalColumn: "Id");
        }
    }
}
