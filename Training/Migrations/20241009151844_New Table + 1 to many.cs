using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training.Migrations
{
    /// <inheritdoc />
    public partial class NewTable1tomany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Cows",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FarmerId",
                table: "Cows",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Farmers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cows_FarmerId",
                table: "Cows",
                column: "FarmerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cows_Farmers_FarmerId",
                table: "Cows",
                column: "FarmerId",
                principalTable: "Farmers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cows_Farmers_FarmerId",
                table: "Cows");

            migrationBuilder.DropTable(
                name: "Farmers");

            migrationBuilder.DropIndex(
                name: "IX_Cows_FarmerId",
                table: "Cows");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Cows");

            migrationBuilder.DropColumn(
                name: "FarmerId",
                table: "Cows");
        }
    }
}
