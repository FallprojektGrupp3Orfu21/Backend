using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class Seed3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpenseDate",
                value: new DateTime(2022, 1, 27, 16, 55, 1, 430, DateTimeKind.Local).AddTicks(4132));

            migrationBuilder.UpdateData(
                table: "ExpensesCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 1, 27, 16, 55, 1, 430, DateTimeKind.Local).AddTicks(4116));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 1, 27, 16, 55, 1, 430, DateTimeKind.Local).AddTicks(3903));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 1, 27, 16, 55, 1, 430, DateTimeKind.Local).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2022, 1, 27, 16, 55, 1, 430, DateTimeKind.Local).AddTicks(3950));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2022, 1, 27, 16, 55, 1, 430, DateTimeKind.Local).AddTicks(3953));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2022, 1, 27, 16, 55, 1, 430, DateTimeKind.Local).AddTicks(3955));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2022, 1, 27, 16, 55, 1, 430, DateTimeKind.Local).AddTicks(3958));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2022, 1, 27, 16, 55, 1, 430, DateTimeKind.Local).AddTicks(3960));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpenseDate",
                value: new DateTime(2022, 1, 27, 16, 52, 38, 739, DateTimeKind.Local).AddTicks(3174));

            migrationBuilder.UpdateData(
                table: "ExpensesCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 1, 27, 16, 52, 38, 739, DateTimeKind.Local).AddTicks(3118));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 1, 27, 16, 52, 38, 739, DateTimeKind.Local).AddTicks(2638));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 1, 27, 16, 52, 38, 739, DateTimeKind.Local).AddTicks(2694));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2022, 1, 27, 16, 52, 38, 739, DateTimeKind.Local).AddTicks(2701));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2022, 1, 27, 16, 52, 38, 739, DateTimeKind.Local).AddTicks(2704));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2022, 1, 27, 16, 52, 38, 739, DateTimeKind.Local).AddTicks(2708));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2022, 1, 27, 16, 52, 38, 739, DateTimeKind.Local).AddTicks(2711));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2022, 1, 27, 16, 52, 38, 739, DateTimeKind.Local).AddTicks(2715));
        }
    }
}
