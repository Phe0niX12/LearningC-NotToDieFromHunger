using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training.Migrations
{
    /// <inheritdoc />
    public partial class DA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cows_Shops_FarmerId1",
                table: "Cows");

            migrationBuilder.DropIndex(
                name: "IX_Cows_FarmerId1",
                table: "Cows");

            migrationBuilder.DropColumn(
                name: "FarmerId1",
                table: "Cows");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FarmerId1",
                table: "Cows",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cows_FarmerId1",
                table: "Cows",
                column: "FarmerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cows_Shops_FarmerId1",
                table: "Cows",
                column: "FarmerId1",
                principalTable: "Shops",
                principalColumn: "Id");
        }
    }
}
