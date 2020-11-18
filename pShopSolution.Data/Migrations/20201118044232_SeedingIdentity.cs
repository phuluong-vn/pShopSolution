using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pShopSolution.Data.Migrations
{
    public partial class SeedingIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 18, 11, 42, 30, 822, DateTimeKind.Local).AddTicks(9382),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 11, 18, 11, 29, 27, 204, DateTimeKind.Local).AddTicks(4909));

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("b0eeed3d-5092-4789-a760-e252aa217e3c"), "6bc0066f-fdc9-4c50-932a-075a44f2b865", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("30dcd73b-c849-44ac-bca3-e48e2843691b"), 0, "db15650e-2023-42ed-86ab-1bf6c6df9fb7", new DateTime(2020, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "phuluong2019@gmail.com", true, "Phú", "Lương", false, null, "phuluong2019@gmail.com", "admin", "AQAAAAEAACcQAAAAEGzp8M6GtSwLB8DtqrS/B7SnkIgfu16FKMGlwPTb6szHTB5etvq8nvvd+hXxm9LBSw==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("b0eeed3d-5092-4789-a760-e252aa217e3c"), new Guid("30dcd73b-c849-44ac-bca3-e48e2843691b") });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2020, 11, 18, 11, 42, 30, 853, DateTimeKind.Local).AddTicks(59));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("b0eeed3d-5092-4789-a760-e252aa217e3c"));

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("30dcd73b-c849-44ac-bca3-e48e2843691b"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b0eeed3d-5092-4789-a760-e252aa217e3c"), new Guid("30dcd73b-c849-44ac-bca3-e48e2843691b") });

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 18, 11, 29, 27, 204, DateTimeKind.Local).AddTicks(4909),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 11, 18, 11, 42, 30, 822, DateTimeKind.Local).AddTicks(9382));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2020, 11, 18, 11, 29, 27, 248, DateTimeKind.Local).AddTicks(5735));
        }
    }
}
