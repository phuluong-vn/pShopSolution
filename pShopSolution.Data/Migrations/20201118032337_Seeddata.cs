using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pShopSolution.Data.Migrations
{
    public partial class Seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeoAlias",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 18, 10, 23, 36, 326, DateTimeKind.Local).AddTicks(3448),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 11, 17, 17, 2, 37, 982, DateTimeKind.Local).AddTicks(9831));

            migrationBuilder.InsertData(
                table: "AppConfigs",
                columns: new[] { "Key", "Value" },
                values: new object[,]
                {
                    { "HomeTiltle", "This is home page of pShopSolution" },
                    { "HomeKeyword", "This is keyword of pShopSolution" },
                    { "HomeDescription", "This is description of pShopSolution" }
                });

            migrationBuilder.InsertData(
                table: "Caegories",
                columns: new[] { "Id", "IsShowOnHome", "ParentId", "SortOrder", "Status" },
                values: new object[,]
                {
                    { 1, true, null, 1, 1 },
                    { 2, true, null, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "IsDefault", "Name" },
                values: new object[,]
                {
                    { "vi-VN", true, "Tiếng Việt" },
                    { "en-US", true, "English" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DateCreate", "OriginalPrice", "Price" },
                values: new object[] { 1, new DateTime(2020, 11, 18, 10, 23, 36, 353, DateTimeKind.Local).AddTicks(264), 100000m, 200000m });

            migrationBuilder.InsertData(
                table: "CategoryTranslations",
                columns: new[] { "Id", "CategoryId", "LanguageId", "Name", "SeoAlias", "SeoDescription", "SeoTitle" },
                values: new object[,]
                {
                    { 1, 1, "vi-VN", "Áo nam", "ao-nam", "Sản phẩm thời trang áo nam", "Sản phẩm thời trang áo nam" },
                    { 3, 2, "vi-VN", "Áo nữ", "ao-nu", "Sản phẩm thời trang áo nam", "Sản phẩm thời trang áo nu" },
                    { 2, 1, "en-US", "Men Shirt", "men-shirt", "The shirt product for men", "The shirt product for men" },
                    { 4, 2, "en-US", "Women Shirt", "women-shirt", "The shirt product for women", "The shirt product for women" }
                });

            migrationBuilder.InsertData(
                table: "ProductInCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ProductTranslations",
                columns: new[] { "Id", "Description", "Details", "LanguageId", "Name", "ProductId", "SeoAlias", "SeoDescription", "SeoTitle" },
                values: new object[,]
                {
                    { 1, "Sản phẩm thời trang áo sơ mi nam Việt Tiến", "Sản phẩm thời trang áo sơ mi nam Việt Tiến", "vi-VN", "Áo sơ mi nam Việt Tiến", 1, "ao-so-mi-nam-Viet-Tien", "Sản phẩm thời trang áo sơ mi nam Việt Tiến", "Sản phẩm thời trang áo sơ mi nam Việt Tiến" },
                    { 2, "The Viet Tien t-shirt product for men", "The Viet Tien t-shirt product for men", "en-US", "Viet Tien Men T-Shirt", 1, "viet-tien-men-t-shirt", "The Viet Tien shirt product for men", "The Viet Tien shirt product for men" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeDescription");

            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeKeyword");

            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeTiltle");

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductInCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Caegories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Caegories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "en-US");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "vi-VN");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "SeoAlias",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 17, 17, 2, 37, 982, DateTimeKind.Local).AddTicks(9831),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 11, 18, 10, 23, 36, 326, DateTimeKind.Local).AddTicks(3448));
        }
    }
}
