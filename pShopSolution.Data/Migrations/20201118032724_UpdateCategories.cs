using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pShopSolution.Data.Migrations
{
    public partial class UpdateCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTranslations_Caegories_CategoryId",
                table: "CategoryTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInCategories_Caegories_CategoryId",
                table: "ProductInCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Caegories",
                table: "Caegories");

            migrationBuilder.RenameTable(
                name: "Caegories",
                newName: "Categories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 18, 10, 27, 22, 973, DateTimeKind.Local).AddTicks(9789),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 11, 18, 10, 23, 36, 326, DateTimeKind.Local).AddTicks(3448));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2020, 11, 18, 10, 27, 22, 998, DateTimeKind.Local).AddTicks(5561));

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTranslations_Categories_CategoryId",
                table: "CategoryTranslations",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInCategories_Categories_CategoryId",
                table: "ProductInCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTranslations_Categories_CategoryId",
                table: "CategoryTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInCategories_Categories_CategoryId",
                table: "ProductInCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Caegories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 18, 10, 23, 36, 326, DateTimeKind.Local).AddTicks(3448),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 11, 18, 10, 27, 22, 973, DateTimeKind.Local).AddTicks(9789));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Caegories",
                table: "Caegories",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2020, 11, 18, 10, 23, 36, 353, DateTimeKind.Local).AddTicks(264));

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTranslations_Caegories_CategoryId",
                table: "CategoryTranslations",
                column: "CategoryId",
                principalTable: "Caegories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInCategories_Caegories_CategoryId",
                table: "ProductInCategories",
                column: "CategoryId",
                principalTable: "Caegories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
