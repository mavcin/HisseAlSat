using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TS.EasyStockManager.Data.Migrations
{
    public partial class Createdb1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 1, 47, 35, 793, DateTimeKind.Local).AddTicks(3656));

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 1, 47, 35, 793, DateTimeKind.Local).AddTicks(582));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 1, 47, 35, 785, DateTimeKind.Local).AddTicks(8498));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 1, 47, 35, 786, DateTimeKind.Local).AddTicks(7979));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 1, 47, 35, 786, DateTimeKind.Local).AddTicks(8008));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 1, 47, 35, 788, DateTimeKind.Local).AddTicks(1375));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 1, 47, 35, 788, DateTimeKind.Local).AddTicks(1551));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 1, 47, 35, 788, DateTimeKind.Local).AddTicks(1559));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 1, 47, 35, 792, DateTimeKind.Local).AddTicks(7585));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 1, 44, 25, 62, DateTimeKind.Local).AddTicks(7068));

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 1, 44, 25, 62, DateTimeKind.Local).AddTicks(3827));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 1, 44, 25, 34, DateTimeKind.Local).AddTicks(5602));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 1, 44, 25, 35, DateTimeKind.Local).AddTicks(6130));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 1, 44, 25, 35, DateTimeKind.Local).AddTicks(6162));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 1, 44, 25, 37, DateTimeKind.Local).AddTicks(541));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 1, 44, 25, 37, DateTimeKind.Local).AddTicks(798));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 1, 44, 25, 37, DateTimeKind.Local).AddTicks(807));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 1, 44, 25, 62, DateTimeKind.Local).AddTicks(656));
        }
    }
}
