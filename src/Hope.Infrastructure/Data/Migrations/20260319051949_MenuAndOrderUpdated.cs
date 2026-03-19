using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hope.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class MenuAndOrderUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastUpdate",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "To",
                table: "Orders",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly[]>(
                name: "AvailableMonths",
                table: "Menus",
                type: "date[]",
                nullable: false,
                defaultValue: new DateOnly[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "To",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AvailableMonths",
                table: "Menus");
        }
    }
}
