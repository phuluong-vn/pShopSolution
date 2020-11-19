using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pShopSolution.Data.Migrations
{
    public partial class ChangeTitleImageAndChangeFileLengthType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImgaPath",
                table: "ProductImage",
                newName: "ImagePath");

            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                table: "ProductImage",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("b0eeed3d-5092-4789-a760-e252aa217e3c"),
                column: "ConcurrencyStamp",
                value: "8f629bc6-7132-40e0-9a4d-2c42bc9fa3ca");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("30dcd73b-c849-44ac-bca3-e48e2843691b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1b001c3e-5780-4abc-8546-6054713c33dd", "AQAAAAEAACcQAAAAEPtmou7k4FmFZwi4ylSUJ2MIgHqoWbCCtbzIsYVN6gyipvON61r0Xl4a18dsJhNLbg==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2020, 11, 18, 18, 4, 5, 837, DateTimeKind.Local).AddTicks(9119));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "ProductImage",
                newName: "ImgaPath");

            migrationBuilder.AlterColumn<int>(
                name: "FileSize",
                table: "ProductImage",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

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
        }
    }
}
