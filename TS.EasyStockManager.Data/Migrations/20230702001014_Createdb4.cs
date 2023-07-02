using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TS.EasyStockManager.Data.Migrations
{
    public partial class Createdb4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreStock_Store_StoreId",
                table: "StoreStock");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Store_StoreId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Store_ToStoreId",
                table: "Transaction");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.RenameColumn(
                name: "StoreId",
                table: "StoreStock",
                newName: "TelegramId");

            migrationBuilder.CreateTable(
                name: "Telegram",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TelegramName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TelegramComment = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telegram", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 3, 10, 13, 436, DateTimeKind.Local).AddTicks(9161));

            migrationBuilder.InsertData(
                table: "Telegram",
                columns: new[] { "Id", "CreateDate", "TelegramComment", "TelegramName" },
                values: new object[] { 1, new DateTime(2023, 7, 2, 3, 10, 13, 436, DateTimeKind.Local).AddTicks(5930), "Example Store", "EX01" });

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 3, 10, 13, 424, DateTimeKind.Local).AddTicks(3999));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 3, 10, 13, 425, DateTimeKind.Local).AddTicks(4447));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 3, 10, 13, 425, DateTimeKind.Local).AddTicks(4485));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 3, 10, 13, 427, DateTimeKind.Local).AddTicks(1748));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 3, 10, 13, 427, DateTimeKind.Local).AddTicks(2029));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 3, 10, 13, 427, DateTimeKind.Local).AddTicks(2039));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 3, 10, 13, 436, DateTimeKind.Local).AddTicks(3008));

            migrationBuilder.AddForeignKey(
                name: "FK_StoreStock_Telegram_TelegramId",
                table: "StoreStock",
                column: "TelegramId",
                principalTable: "Telegram",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Telegram_StoreId",
                table: "Transaction",
                column: "StoreId",
                principalTable: "Telegram",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Telegram_ToStoreId",
                table: "Transaction",
                column: "ToStoreId",
                principalTable: "Telegram",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreStock_Telegram_TelegramId",
                table: "StoreStock");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Telegram_StoreId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Telegram_ToStoreId",
                table: "Transaction");

            migrationBuilder.DropTable(
                name: "Telegram");

            migrationBuilder.RenameColumn(
                name: "TelegramId",
                table: "StoreStock",
                newName: "StoreId");

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StoreCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    StoreName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 2, 29, 33, 855, DateTimeKind.Local).AddTicks(9167));

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "Id", "CreateDate", "StoreCode", "StoreName" },
                values: new object[] { 1, new DateTime(2023, 7, 2, 2, 29, 33, 855, DateTimeKind.Local).AddTicks(5817), "EX01", "Example Store" });

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 2, 29, 33, 841, DateTimeKind.Local).AddTicks(5307));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 2, 29, 33, 843, DateTimeKind.Local).AddTicks(2739));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 2, 29, 33, 843, DateTimeKind.Local).AddTicks(2813));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 2, 29, 33, 846, DateTimeKind.Local).AddTicks(1503));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 2, 29, 33, 846, DateTimeKind.Local).AddTicks(2040));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 2, 29, 33, 846, DateTimeKind.Local).AddTicks(2057));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 2, 29, 33, 855, DateTimeKind.Local).AddTicks(2590));

            migrationBuilder.AddForeignKey(
                name: "FK_StoreStock_Store_StoreId",
                table: "StoreStock",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Store_StoreId",
                table: "Transaction",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Store_ToStoreId",
                table: "Transaction",
                column: "ToStoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
