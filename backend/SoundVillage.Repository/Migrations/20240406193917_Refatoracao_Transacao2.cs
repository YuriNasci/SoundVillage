using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoundVillage.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Refatoracao_Transacao2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacao_ContaBancaria_ContaBancariaDestinoId",
                table: "Transacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacao_ContaBancaria_ContaBancariaOrigemId",
                table: "Transacao");

            migrationBuilder.DropIndex(
                name: "IX_Transacao_ContaBancariaDestinoId",
                table: "Transacao");

            migrationBuilder.DropIndex(
                name: "IX_Transacao_ContaBancariaOrigemId",
                table: "Transacao");

            migrationBuilder.DropColumn(
                name: "ContaBancariaDestinoId",
                table: "Transacao");

            migrationBuilder.DropColumn(
                name: "ContaBancariaOrigemId",
                table: "Transacao");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "Transacao",
                newName: "ValorTransacao");

            migrationBuilder.RenameColumn(
                name: "Horario",
                table: "Transacao",
                newName: "DtTransacao");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Transacao",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "MerchantNome",
                table: "Transacao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MerchantNome",
                table: "Transacao");

            migrationBuilder.RenameColumn(
                name: "ValorTransacao",
                table: "Transacao",
                newName: "Valor");

            migrationBuilder.RenameColumn(
                name: "DtTransacao",
                table: "Transacao",
                newName: "Horario");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Transacao",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<Guid>(
                name: "ContaBancariaDestinoId",
                table: "Transacao",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ContaBancariaOrigemId",
                table: "Transacao",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_ContaBancariaDestinoId",
                table: "Transacao",
                column: "ContaBancariaDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_ContaBancariaOrigemId",
                table: "Transacao",
                column: "ContaBancariaOrigemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacao_ContaBancaria_ContaBancariaDestinoId",
                table: "Transacao",
                column: "ContaBancariaDestinoId",
                principalTable: "ContaBancaria",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacao_ContaBancaria_ContaBancariaOrigemId",
                table: "Transacao",
                column: "ContaBancariaOrigemId",
                principalTable: "ContaBancaria",
                principalColumn: "Id");
        }
    }
}
