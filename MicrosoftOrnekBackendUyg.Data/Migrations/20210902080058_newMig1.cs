using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MicrosoftOrnekBackendUyg.Data.Migrations
{
    public partial class newMig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceActivities_Users_UserId",
                table: "InvoiceActivities");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceActivities_UserId",
                table: "InvoiceActivities");

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Category", "CompanyCode", "Name" },
                values: new object[,]
                {
                    { 1, 1, 100, "Elektrik Firması" },
                    { 2, 2, 101, "Su Firması" },
                    { 3, 3, 102, "Doğalgaz Firması" },
                    { 4, 4, 103, "İnternet Firması" },
                    { 5, 5, 104, "Mobil Operatör Firması" },
                    { 6, 6, 105, "Tv Yayın Firması" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Authorization", "CreatedAt", "Iban", "Mail", "Name", "PhoneNu", "Surname", "TcNu", "UserName" },
                values: new object[,]
                {
                    { 1, "Erzurum", 2, new DateTime(2021, 9, 1, 10, 25, 0, 0, DateTimeKind.Unspecified), 1, "muhammedkaradastr@gmail.com", "Muhammed ", "05342906884", "Karadaş1", 1, "superadmin" },
                    { 2, "İstanbul", 1, new DateTime(2021, 9, 2, 12, 25, 0, 0, DateTimeKind.Unspecified), 2, "muti5@windowslive.com", "Muhammed", "05342906884", "Karadaş2", 2, "normaladmin" },
                    { 3, "Erzurum", 0, new DateTime(2021, 9, 3, 15, 35, 0, 0, DateTimeKind.Unspecified), 3, "muti323@gmail.com", "Muhammed", "05342906884", "Karadaş3", 3, "normaluser" }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceId", "CompanyId", "DueDate", "ExcludingVat", "InvoiceNu", "InvoiceType", "IsComplete", "Name", "StatusCode", "Total", "TotalVat", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 9, 1, 13, 35, 0, 0, DateTimeKind.Unspecified), 80m, 1, 0, 0, "Elektrik Faturası Örneği", 0, 150m, 70m, 1 },
                    { 2, 1, new DateTime(2021, 9, 2, 10, 5, 0, 0, DateTimeKind.Unspecified), 110m, 2, 1, 1, "Su Faturası Örneği", 1, 170m, 60m, 1 },
                    { 3, 1, new DateTime(2021, 9, 3, 11, 5, 0, 0, DateTimeKind.Unspecified), 140m, 3, 1, 1, "Doğalgaz Faturası Örneği", 1, 200m, 60m, 1 },
                    { 4, 1, new DateTime(2021, 9, 4, 12, 5, 0, 0, DateTimeKind.Unspecified), 40m, 4, 1, 1, "İnternet Faturası Örneği", 1, 100m, 60m, 1 },
                    { 5, 1, new DateTime(2021, 9, 5, 12, 25, 0, 0, DateTimeKind.Unspecified), 30m, 5, 1, 1, "Mobil Fatura Örneği", 1, 50m, 20m, 1 },
                    { 6, 1, new DateTime(2021, 9, 6, 15, 5, 25, 0, DateTimeKind.Unspecified), 40m, 6, 1, 1, "Tv Yayın Faturası Örneği", 1, 100m, 60m, 1 }
                });

            migrationBuilder.InsertData(
                table: "InvoiceActivities",
                columns: new[] { "Id", "CompanyId", "InvoiceId", "StatusCode", "TransactionDate", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1, 0, new DateTime(2021, 9, 1, 10, 5, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, 2, 1, new DateTime(2021, 9, 2, 11, 25, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 3, 3, 2, new DateTime(2021, 9, 3, 12, 5, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, 4, 4, 3, new DateTime(2021, 9, 4, 14, 5, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 5, 5, 5, 50, new DateTime(2021, 9, 5, 15, 25, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, 6, 6, -1, new DateTime(2021, 9, 6, 16, 5, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_UserId",
                table: "Invoices",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Users_UserId",
                table: "Invoices",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Users_UserId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_UserId",
                table: "Invoices");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "InvoiceActivities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InvoiceActivities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InvoiceActivities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "InvoiceActivities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "InvoiceActivities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "InvoiceActivities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    InnerBarcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
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
                values: new object[] { 1, false, "Kalemler" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[] { 2, false, "Defterler" });

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
                name: "IX_InvoiceActivities_UserId",
                table: "InvoiceActivities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceActivities_Users_UserId",
                table: "InvoiceActivities",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
