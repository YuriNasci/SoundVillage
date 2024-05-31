using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoundVillage.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Notificacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cartao_ContasBancarias_ContaBancariaId",
                table: "Cartao");

            migrationBuilder.DropForeignKey(
                name: "FK_Notificacao_ContasBancarias_ContaBancariaId",
                table: "Notificacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Notificacao_ContasBancarias_ContaId",
                table: "Notificacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Planos_ContasBancarias_ContaBancariaId",
                table: "Planos");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_ContasBancarias_ContaDestinoId",
                table: "Transacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_ContasBancarias_ContaOrigemId",
                table: "Transacoes");

            migrationBuilder.DropIndex(
                name: "IX_Notificacao_ContaBancariaId",
                table: "Notificacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContasBancarias",
                table: "ContasBancarias");

            migrationBuilder.DropColumn(
                name: "ContaBancariaId",
                table: "Notificacao");

            migrationBuilder.RenameTable(
                name: "ContasBancarias",
                newName: "ContaBancaria");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContaBancaria",
                table: "ContaBancaria",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cartao_ContaBancaria_ContaBancariaId",
                table: "Cartao",
                column: "ContaBancariaId",
                principalTable: "ContaBancaria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notificacao_ContaBancaria_ContaId",
                table: "Notificacao",
                column: "ContaId",
                principalTable: "ContaBancaria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Planos_ContaBancaria_ContaBancariaId",
                table: "Planos",
                column: "ContaBancariaId",
                principalTable: "ContaBancaria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_ContaBancaria_ContaDestinoId",
                table: "Transacoes",
                column: "ContaDestinoId",
                principalTable: "ContaBancaria",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_ContaBancaria_ContaOrigemId",
                table: "Transacoes",
                column: "ContaOrigemId",
                principalTable: "ContaBancaria",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cartao_ContaBancaria_ContaBancariaId",
                table: "Cartao");

            migrationBuilder.DropForeignKey(
                name: "FK_Notificacao_ContaBancaria_ContaId",
                table: "Notificacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Planos_ContaBancaria_ContaBancariaId",
                table: "Planos");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_ContaBancaria_ContaDestinoId",
                table: "Transacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_ContaBancaria_ContaOrigemId",
                table: "Transacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContaBancaria",
                table: "ContaBancaria");

            migrationBuilder.RenameTable(
                name: "ContaBancaria",
                newName: "ContasBancarias");

            migrationBuilder.AddColumn<Guid>(
                name: "ContaBancariaId",
                table: "Notificacao",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContasBancarias",
                table: "ContasBancarias",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacao_ContaBancariaId",
                table: "Notificacao",
                column: "ContaBancariaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cartao_ContasBancarias_ContaBancariaId",
                table: "Cartao",
                column: "ContaBancariaId",
                principalTable: "ContasBancarias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notificacao_ContasBancarias_ContaBancariaId",
                table: "Notificacao",
                column: "ContaBancariaId",
                principalTable: "ContasBancarias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notificacao_ContasBancarias_ContaId",
                table: "Notificacao",
                column: "ContaId",
                principalTable: "ContasBancarias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Planos_ContasBancarias_ContaBancariaId",
                table: "Planos",
                column: "ContaBancariaId",
                principalTable: "ContasBancarias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_ContasBancarias_ContaDestinoId",
                table: "Transacoes",
                column: "ContaDestinoId",
                principalTable: "ContasBancarias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_ContasBancarias_ContaOrigemId",
                table: "Transacoes",
                column: "ContaOrigemId",
                principalTable: "ContasBancarias",
                principalColumn: "Id");
        }
    }
}
