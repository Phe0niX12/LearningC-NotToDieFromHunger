using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training.Migrations
{
    /// <inheritdoc />
    public partial class S : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FarmerId1",
                table: "Cows",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customersPerYear = table.Column<int>(type: "int", nullable: true),
                    managerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FarmerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shops_Farmers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Traidings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FarmerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShopsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traidings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Traidings_Farmers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Traidings_Shops_ShopsId",
                        column: x => x.ShopsId,
                        principalTable: "Shops",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cows_FarmerId1",
                table: "Cows",
                column: "FarmerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_FarmerId",
                table: "Shops",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_Traidings_FarmerId",
                table: "Traidings",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_Traidings_ShopsId",
                table: "Traidings",
                column: "ShopsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cows_Shops_FarmerId1",
                table: "Cows",
                column: "FarmerId1",
                principalTable: "Shops",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cows_Shops_FarmerId1",
                table: "Cows");

            migrationBuilder.DropTable(
                name: "Traidings");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropIndex(
                name: "IX_Cows_FarmerId1",
                table: "Cows");

            migrationBuilder.DropColumn(
                name: "FarmerId1",
                table: "Cows");
        }
    }
}
