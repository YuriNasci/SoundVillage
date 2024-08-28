using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SoundVillage.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ContaBancaria",
                columns: new[] { "Id", "Cpf", "Digito", "Nome", "NumeroAgencia", "NumeroConta", "Saldo" },
                values: new object[] { new Guid("f825761f-2621-46cc-a24b-21852a3e918d"), "11122233344", "9", "Conta Cobradora", "9876", "54321", 0m });

            migrationBuilder.InsertData(
                table: "Planos",
                columns: new[] { "Id", "ContaBancariaId", "Descricao", "Nome", "Recorrencia", "Valor" },
                values: new object[,]
                {
                    { new Guid("0f2108e3-6968-4d5b-ae9a-87667e7bc60d"), new Guid("f825761f-2621-46cc-a24b-21852a3e918d"), "Plano com funcionalidades básicas", "Plano Básico", 0, 9.99m },
                    { new Guid("4bf62345-0101-4dd0-9297-4eb541aa06cf"), new Guid("f825761f-2621-46cc-a24b-21852a3e918d"), "Plano com todas as funcionalidades", "Plano Premium", 2, 19.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Planos",
                keyColumn: "Id",
                keyValue: new Guid("0f2108e3-6968-4d5b-ae9a-87667e7bc60d"));

            migrationBuilder.DeleteData(
                table: "Planos",
                keyColumn: "Id",
                keyValue: new Guid("4bf62345-0101-4dd0-9297-4eb541aa06cf"));

            migrationBuilder.DeleteData(
                table: "ContaBancaria",
                keyColumn: "Id",
                keyValue: new Guid("f825761f-2621-46cc-a24b-21852a3e918d"));
        }
    }
}
