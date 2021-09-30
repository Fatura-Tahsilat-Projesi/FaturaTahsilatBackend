using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MicrosoftOrnekBackendUyg.Data.Migrations
{
    public partial class intToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropForeignKey(
                name: "FK_Invoices_CustomUsers_UserId",
                table: "Invoices");*/

            /*migrationBuilder.DropTable(
                name: "Log");*/

            /*migrationBuilder.DropIndex(
                name: "IX_Invoices_UserId",
                table: "Invoices");*/

            migrationBuilder.UpdateData(
                table: "InvoiceActivities",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "InvoiceActivities",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "InvoiceActivities",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserId",
                value: 6);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageTemplate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Properties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Log_CustomUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "CustomUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "InvoiceActivities",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "InvoiceActivities",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "InvoiceActivities",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_UserId",
                table: "Invoices",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Log_UserId",
                table: "Log",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_CustomUsers_UserId",
                table: "Invoices",
                column: "UserId",
                principalTable: "CustomUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
