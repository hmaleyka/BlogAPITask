using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.DAL.Migrations
{
    public partial class makings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ViewerCount",
                table: "blogs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "blogs",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "Getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 12, 2, 45, 24, 538, DateTimeKind.Utc).AddTicks(6166));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ViewerCount",
                table: "blogs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 12, 2, 45, 24, 538, DateTimeKind.Utc).AddTicks(6166),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "Getutcdate()");
        }
    }
}
