using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoundVillage.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Refactor_Cartao4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assinatura_ContaStreaming_ContaStreamingId",
                table: "Assinatura");

            migrationBuilder.DropForeignKey(
                name: "FK_Cartao_ContaStreaming_ContaStreamingId",
                table: "Cartao");

            migrationBuilder.DropIndex(
                name: "IX_Cartao_ContaStreamingId",
                table: "Cartao");

            migrationBuilder.DropIndex(
                name: "IX_Assinatura_ContaStreamingId",
                table: "Assinatura");

            migrationBuilder.DropColumn(
                name: "ContaStreamingId",
                table: "Cartao");

            migrationBuilder.DropColumn(
                name: "ContaStreamingId",
                table: "Assinatura");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ContaStreamingId",
                table: "Cartao",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ContaStreamingId",
                table: "Assinatura",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cartao_ContaStreamingId",
                table: "Cartao",
                column: "ContaStreamingId");

            migrationBuilder.CreateIndex(
                name: "IX_Assinatura_ContaStreamingId",
                table: "Assinatura",
                column: "ContaStreamingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assinatura_ContaStreaming_ContaStreamingId",
                table: "Assinatura",
                column: "ContaStreamingId",
                principalTable: "ContaStreaming",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cartao_ContaStreaming_ContaStreamingId",
                table: "Cartao",
                column: "ContaStreamingId",
                principalTable: "ContaStreaming",
                principalColumn: "Id");
        }
    }
}
