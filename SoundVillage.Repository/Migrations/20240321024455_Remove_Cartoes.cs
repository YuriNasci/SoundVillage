using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoundVillage.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Cartoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assinatura_Cartoes_CartaoPagamentoId",
                table: "Assinatura");

            migrationBuilder.DropForeignKey(
                name: "FK_Cartoes_ContaStreaming_ContaStreamingId",
                table: "Cartoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Cartoes_ContasBancarias_ContaBancariaId",
                table: "Cartoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Cartoes_ContasBancarias_ContaBancariaId1",
                table: "Cartoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Cartoes_CartaoId",
                table: "Transacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cartoes",
                table: "Cartoes");

            migrationBuilder.DropIndex(
                name: "IX_Cartoes_ContaBancariaId1",
                table: "Cartoes");

            migrationBuilder.DropColumn(
                name: "ContaBancariaId1",
                table: "Cartoes");

            migrationBuilder.RenameTable(
                name: "Cartoes",
                newName: "Cartao");

            migrationBuilder.RenameIndex(
                name: "IX_Cartoes_ContaStreamingId",
                table: "Cartao",
                newName: "IX_Cartao_ContaStreamingId");

            migrationBuilder.RenameIndex(
                name: "IX_Cartoes_ContaBancariaId",
                table: "Cartao",
                newName: "IX_Cartao_ContaBancariaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cartao",
                table: "Cartao",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assinatura_Cartao_CartaoPagamentoId",
                table: "Assinatura",
                column: "CartaoPagamentoId",
                principalTable: "Cartao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cartao_ContaStreaming_ContaStreamingId",
                table: "Cartao",
                column: "ContaStreamingId",
                principalTable: "ContaStreaming",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cartao_ContasBancarias_ContaBancariaId",
                table: "Cartao",
                column: "ContaBancariaId",
                principalTable: "ContasBancarias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Cartao_CartaoId",
                table: "Transacoes",
                column: "CartaoId",
                principalTable: "Cartao",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assinatura_Cartao_CartaoPagamentoId",
                table: "Assinatura");

            migrationBuilder.DropForeignKey(
                name: "FK_Cartao_ContaStreaming_ContaStreamingId",
                table: "Cartao");

            migrationBuilder.DropForeignKey(
                name: "FK_Cartao_ContasBancarias_ContaBancariaId",
                table: "Cartao");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Cartao_CartaoId",
                table: "Transacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cartao",
                table: "Cartao");

            migrationBuilder.RenameTable(
                name: "Cartao",
                newName: "Cartoes");

            migrationBuilder.RenameIndex(
                name: "IX_Cartao_ContaStreamingId",
                table: "Cartoes",
                newName: "IX_Cartoes_ContaStreamingId");

            migrationBuilder.RenameIndex(
                name: "IX_Cartao_ContaBancariaId",
                table: "Cartoes",
                newName: "IX_Cartoes_ContaBancariaId");

            migrationBuilder.AddColumn<Guid>(
                name: "ContaBancariaId1",
                table: "Cartoes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cartoes",
                table: "Cartoes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cartoes_ContaBancariaId1",
                table: "Cartoes",
                column: "ContaBancariaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Assinatura_Cartoes_CartaoPagamentoId",
                table: "Assinatura",
                column: "CartaoPagamentoId",
                principalTable: "Cartoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cartoes_ContaStreaming_ContaStreamingId",
                table: "Cartoes",
                column: "ContaStreamingId",
                principalTable: "ContaStreaming",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cartoes_ContasBancarias_ContaBancariaId",
                table: "Cartoes",
                column: "ContaBancariaId",
                principalTable: "ContasBancarias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cartoes_ContasBancarias_ContaBancariaId1",
                table: "Cartoes",
                column: "ContaBancariaId1",
                principalTable: "ContasBancarias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Cartoes_CartaoId",
                table: "Transacoes",
                column: "CartaoId",
                principalTable: "Cartoes",
                principalColumn: "Id");
        }
    }
}
