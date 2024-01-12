using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.DAL.Migrations
{
    public partial class addViewCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 12, 2, 45, 24, 538, DateTimeKind.Utc).AddTicks(6166),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 10, 16, 24, 25, 485, DateTimeKind.Utc).AddTicks(4938));

            migrationBuilder.AddColumn<int>(
                name: "ViewerCount",
                table: "blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewerCount",
                table: "blogs");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 10, 16, 24, 25, 485, DateTimeKind.Utc).AddTicks(4938),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 12, 2, 45, 24, 538, DateTimeKind.Utc).AddTicks(6166));
        }
    }
}
