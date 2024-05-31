using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoundVillage.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Refatoracao_Cartao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cartao_ContaBancaria_ContaBancariaId",
                table: "Cartao");

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Cartao",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "ContaBancariaId",
                table: "Cartao",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Cartao_ContaBancaria_ContaBancariaId",
                table: "Cartao",
                column: "ContaBancariaId",
                principalTable: "ContaBancaria",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cartao_ContaBancaria_ContaBancariaId",
                table: "Cartao");

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Cartao",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<Guid>(
                name: "ContaBancariaId",
                table: "Cartao",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cartao_ContaBancaria_ContaBancariaId",
                table: "Cartao",
                column: "ContaBancariaId",
                principalTable: "ContaBancaria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
