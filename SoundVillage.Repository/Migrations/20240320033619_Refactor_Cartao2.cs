using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoundVillage.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Refactor_Cartao2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cartoes_ContasBancarias_ContaId",
                table: "Cartoes");

            migrationBuilder.RenameColumn(
                name: "ContaId",
                table: "Cartoes",
                newName: "ContaBancariaId1");

            migrationBuilder.RenameIndex(
                name: "IX_Cartoes_ContaId",
                table: "Cartoes",
                newName: "IX_Cartoes_ContaBancariaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cartoes_ContasBancarias_ContaBancariaId1",
                table: "Cartoes",
                column: "ContaBancariaId1",
                principalTable: "ContasBancarias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cartoes_ContasBancarias_ContaBancariaId1",
                table: "Cartoes");

            migrationBuilder.RenameColumn(
                name: "ContaBancariaId1",
                table: "Cartoes",
                newName: "ContaId");

            migrationBuilder.RenameIndex(
                name: "IX_Cartoes_ContaBancariaId1",
                table: "Cartoes",
                newName: "IX_Cartoes_ContaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cartoes_ContasBancarias_ContaId",
                table: "Cartoes",
                column: "ContaId",
                principalTable: "ContasBancarias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
