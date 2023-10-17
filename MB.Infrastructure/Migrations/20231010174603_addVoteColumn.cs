using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MB.Infrastructure.Migrations
{
    public partial class addVoteColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Vote",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ArticleCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 10, 21, 16, 3, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 13, 33, 4, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vote",
                table: "Comments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ArticleCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 13, 33, 4, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 10, 21, 16, 3, 0, DateTimeKind.Unspecified));
        }
    }
}
