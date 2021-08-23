using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MicrosoftOrnekBackendUyg.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faturalar",
                columns: table => new
                {
                    FaturaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    topkdv = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    kdvsizfiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    son_odeme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    icerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    odendi = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsComplete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faturalar", x => x.FaturaId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    InnerBarcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Kalemler" },
                    { 2, false, "Defterler" }
                });

            migrationBuilder.InsertData(
                table: "Faturalar",
                columns: new[] { "FaturaId", "IsComplete", "Name", "icerik", "kdvsizfiyat", "odendi", "son_odeme", "topkdv", "tutar" },
                values: new object[,]
                {
                    { 1, 0, "Su Faturası", "Su", 30m, 0, new DateTime(2021, 10, 10, 23, 59, 0, 0, DateTimeKind.Unspecified), 70m, 100m },
                    { 2, 0, "Elektrik Faturası", "Elektrik", 60m, 0, new DateTime(2021, 12, 10, 18, 0, 0, 0, DateTimeKind.Unspecified), 60m, 120m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "InnerBarcode", "IsDeleted", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, null, false, "Pilot Kalem", 12.50m, 100 },
                    { 2, 1, null, false, "Kurşun Kalem", 40.50m, 200 },
                    { 3, 1, null, false, "Tükenmez Kalem", 500m, 300 },
                    { 4, 2, null, false, "Küçük Boy Defter", 8m, 250 },
                    { 5, 2, null, false, "Orta Boy Defter", 10m, 250 },
                    { 6, 2, null, false, "Büyük Boy Defter", 12m, 250 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faturalar");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
