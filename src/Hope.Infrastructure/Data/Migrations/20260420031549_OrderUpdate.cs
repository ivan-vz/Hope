using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hope.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class OrderUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Delivered",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "DeliverTo",
                table: "Orders",
                newName: "Message");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Orders",
                newName: "DeliverTo");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Delivered",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true);
        }
    }
}
