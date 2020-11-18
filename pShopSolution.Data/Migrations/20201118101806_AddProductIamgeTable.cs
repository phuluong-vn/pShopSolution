using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pShopSolution.Data.Migrations
{
    public partial class AddProductIamgeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 11, 18, 11, 42, 30, 822, DateTimeKind.Local).AddTicks(9382));

            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ImgaPath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImage_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("b0eeed3d-5092-4789-a760-e252aa217e3c"),
                column: "ConcurrencyStamp",
                value: "946d892d-74be-4b26-a00e-6340aadc6690");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("30dcd73b-c849-44ac-bca3-e48e2843691b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4cf47402-d25c-477b-b082-4f10b179ed18", "AQAAAAEAACcQAAAAEA5/EvGCZ8mUXjKnZF97m4/S4F3sT4xSQIz1K3kDRWP6ctizD8nIwpGGg5iDL7uMSQ==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2020, 11, 18, 17, 18, 5, 146, DateTimeKind.Local).AddTicks(990));

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductId",
                table: "ProductImage",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 18, 11, 42, 30, 822, DateTimeKind.Local).AddTicks(9382),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("b0eeed3d-5092-4789-a760-e252aa217e3c"),
                column: "ConcurrencyStamp",
                value: "6bc0066f-fdc9-4c50-932a-075a44f2b865");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("30dcd73b-c849-44ac-bca3-e48e2843691b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "db15650e-2023-42ed-86ab-1bf6c6df9fb7", "AQAAAAEAACcQAAAAEGzp8M6GtSwLB8DtqrS/B7SnkIgfu16FKMGlwPTb6szHTB5etvq8nvvd+hXxm9LBSw==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2020, 11, 18, 11, 42, 30, 853, DateTimeKind.Local).AddTicks(59));
        }
    }
}
