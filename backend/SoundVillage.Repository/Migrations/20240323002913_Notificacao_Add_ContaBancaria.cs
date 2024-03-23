using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoundVillage.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Notificacao_Add_ContaBancaria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notificacao_ContaBancaria_ContaId",
                table: "Notificacao");

            migrationBuilder.RenameColumn(
                name: "ContaId",
                table: "Notificacao",
                newName: "ContaBancariaId");

            migrationBuilder.RenameIndex(
                name: "IX_Notificacao_ContaId",
                table: "Notificacao",
                newName: "IX_Notificacao_ContaBancariaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notificacao_ContaBancaria_ContaBancariaId",
                table: "Notificacao",
                column: "ContaBancariaId",
                principalTable: "ContaBancaria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notificacao_ContaBancaria_ContaBancariaId",
                table: "Notificacao");

            migrationBuilder.RenameColumn(
                name: "ContaBancariaId",
                table: "Notificacao",
                newName: "ContaId");

            migrationBuilder.RenameIndex(
                name: "IX_Notificacao_ContaBancariaId",
                table: "Notificacao",
                newName: "IX_Notificacao_ContaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notificacao_ContaBancaria_ContaId",
                table: "Notificacao",
                column: "ContaId",
                principalTable: "ContaBancaria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
