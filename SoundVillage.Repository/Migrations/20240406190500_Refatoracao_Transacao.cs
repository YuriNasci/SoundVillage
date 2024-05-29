using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoundVillage.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Refatoracao_Transacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Cartao_CartaoId",
                table: "Transacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_ContaBancaria_ContaDestinoId",
                table: "Transacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_ContaBancaria_ContaOrigemId",
                table: "Transacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transacoes",
                table: "Transacoes");

            migrationBuilder.RenameTable(
                name: "Transacoes",
                newName: "Transacao");

            migrationBuilder.RenameColumn(
                name: "ContaOrigemId",
                table: "Transacao",
                newName: "ContaBancariaOrigemId");

            migrationBuilder.RenameColumn(
                name: "ContaDestinoId",
                table: "Transacao",
                newName: "ContaBancariaDestinoId");

            migrationBuilder.RenameIndex(
                name: "IX_Transacoes_ContaOrigemId",
                table: "Transacao",
                newName: "IX_Transacao_ContaBancariaOrigemId");

            migrationBuilder.RenameIndex(
                name: "IX_Transacoes_ContaDestinoId",
                table: "Transacao",
                newName: "IX_Transacao_ContaBancariaDestinoId");

            migrationBuilder.RenameIndex(
                name: "IX_Transacoes_CartaoId",
                table: "Transacao",
                newName: "IX_Transacao_CartaoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transacao",
                table: "Transacao",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacao_Cartao_CartaoId",
                table: "Transacao",
                column: "CartaoId",
                principalTable: "Cartao",
                principalColumn: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacao_Cartao_CartaoId",
                table: "Transacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacao_ContaBancaria_ContaBancariaDestinoId",
                table: "Transacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacao_ContaBancaria_ContaBancariaOrigemId",
                table: "Transacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transacao",
                table: "Transacao");

            migrationBuilder.RenameTable(
                name: "Transacao",
                newName: "Transacoes");

            migrationBuilder.RenameColumn(
                name: "ContaBancariaOrigemId",
                table: "Transacoes",
                newName: "ContaOrigemId");

            migrationBuilder.RenameColumn(
                name: "ContaBancariaDestinoId",
                table: "Transacoes",
                newName: "ContaDestinoId");

            migrationBuilder.RenameIndex(
                name: "IX_Transacao_ContaBancariaOrigemId",
                table: "Transacoes",
                newName: "IX_Transacoes_ContaOrigemId");

            migrationBuilder.RenameIndex(
                name: "IX_Transacao_ContaBancariaDestinoId",
                table: "Transacoes",
                newName: "IX_Transacoes_ContaDestinoId");

            migrationBuilder.RenameIndex(
                name: "IX_Transacao_CartaoId",
                table: "Transacoes",
                newName: "IX_Transacoes_CartaoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transacoes",
                table: "Transacoes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Cartao_CartaoId",
                table: "Transacoes",
                column: "CartaoId",
                principalTable: "Cartao",
                principalColumn: "Id");

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
    }
}
