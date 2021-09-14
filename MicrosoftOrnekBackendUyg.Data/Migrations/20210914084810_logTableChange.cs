using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MicrosoftOrnekBackendUyg.Data.Migrations
{
    public partial class logTableChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Datetime",
                table: "Log",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Exception",
                table: "Log",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Log",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Log",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MessageTemplate",
                table: "Log",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Properties",
                table: "Log",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "TimeStamp",
                table: "Log",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Exception",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "MessageTemplate",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "Properties",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "Log");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Datetime",
                table: "Log",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
