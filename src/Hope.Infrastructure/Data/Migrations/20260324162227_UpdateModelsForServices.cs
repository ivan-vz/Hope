using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hope.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelsForServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealMenu_Meals_MealsId",
                table: "MealMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_MealMenu_Menus_MenuId",
                table: "MealMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Orders_OrderId",
                table: "Meals");

            migrationBuilder.DropForeignKey(
                name: "FK_MealTag_Meals_MealsId",
                table: "MealTag");

            migrationBuilder.DropForeignKey(
                name: "FK_MealTag_Tags_TagsId",
                table: "MealTag");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Meals_OrderId",
                table: "Meals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealMenu",
                table: "MealMenu");

            migrationBuilder.DropIndex(
                name: "IX_MealMenu_MenuId",
                table: "MealMenu");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Meals");

            migrationBuilder.RenameColumn(
                name: "TagsId",
                table: "MealTag",
                newName: "TagId");

            migrationBuilder.RenameColumn(
                name: "MealsId",
                table: "MealTag",
                newName: "MealId");

            migrationBuilder.RenameIndex(
                name: "IX_MealTag_TagsId",
                table: "MealTag",
                newName: "IX_MealTag_TagId");

            migrationBuilder.RenameColumn(
                name: "MealsId",
                table: "MealMenu",
                newName: "MealId");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Users",
                type: "character varying(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "character varying(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Users",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tags",
                type: "character varying(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Tags",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Orders",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "DeliverTo",
                table: "Orders",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCancelled",
                table: "Orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Menus",
                type: "character varying(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Menus",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Meals",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Meals",
                type: "character varying(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Meals",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Meals",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Meals",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealMenu",
                table: "MealMenu",
                columns: new[] { "MenuId", "MealId" });

            migrationBuilder.CreateTable(
                name: "OrdersMeals",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    MealId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersMeals", x => new { x.OrderId, x.MealId });
                    table.ForeignKey(
                        name: "FK_OrdersMeals_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdersMeals_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_IsDeleted",
                table: "Tags",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Name",
                table: "Tags",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IsCancelled",
                table: "Orders",
                column: "IsCancelled");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_To",
                table: "Orders",
                column: "To");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_IsDeleted",
                table: "Menus",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_Name",
                table: "Menus",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_IsDeleted",
                table: "Meals",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_Name",
                table: "Meals",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MealMenu_MealId",
                table: "MealMenu",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersMeals_MealId",
                table: "OrdersMeals",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealMenu_Meals_MealId",
                table: "MealMenu",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MealMenu_Menus_MenuId",
                table: "MealMenu",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MealTag_Meals_MealId",
                table: "MealTag",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealTag_Tags_TagId",
                table: "MealTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealMenu_Meals_MealId",
                table: "MealMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_MealMenu_Menus_MenuId",
                table: "MealMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_MealTag_Meals_MealId",
                table: "MealTag");

            migrationBuilder.DropForeignKey(
                name: "FK_MealTag_Tags_TagId",
                table: "MealTag");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrdersMeals");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Tags_IsDeleted",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_Name",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Orders_IsCancelled",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_To",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Menus_IsDeleted",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_Name",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Meals_IsDeleted",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_Name",
                table: "Meals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealMenu",
                table: "MealMenu");

            migrationBuilder.DropIndex(
                name: "IX_MealMenu_MealId",
                table: "MealMenu");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "IsCancelled",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Meals");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "MealTag",
                newName: "TagsId");

            migrationBuilder.RenameColumn(
                name: "MealId",
                table: "MealTag",
                newName: "MealsId");

            migrationBuilder.RenameIndex(
                name: "IX_MealTag_TagId",
                table: "MealTag",
                newName: "IX_MealTag_TagsId");

            migrationBuilder.RenameColumn(
                name: "MealId",
                table: "MealMenu",
                newName: "MealsId");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tags",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Orders",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<string>(
                name: "DeliverTo",
                table: "Orders",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Menus",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Meals",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Meals",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Meals",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Meals",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Meals",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealMenu",
                table: "MealMenu",
                columns: new[] { "MealsId", "MenuId" });

            migrationBuilder.CreateIndex(
                name: "IX_Meals_OrderId",
                table: "Meals",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_MealMenu_MenuId",
                table: "MealMenu",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealMenu_Meals_MealsId",
                table: "MealMenu",
                column: "MealsId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealMenu_Menus_MenuId",
                table: "MealMenu",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Orders_OrderId",
                table: "Meals",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MealTag_Meals_MealsId",
                table: "MealTag",
                column: "MealsId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealTag_Tags_TagsId",
                table: "MealTag",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
