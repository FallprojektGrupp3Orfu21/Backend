using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class AddedRecipientNStuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Recipients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ExpenseCategoryId",
                table: "Recipients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Recipients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserNavId",
                table: "Recipients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ExpenseDate" },
                values: new object[] { new DateTime(2022, 2, 10, 14, 22, 55, 118, DateTimeKind.Local).AddTicks(8199), new DateTime(2022, 2, 10, 14, 22, 55, 118, DateTimeKind.Local).AddTicks(8201) });

            migrationBuilder.UpdateData(
                table: "ExpensesCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 2, 10, 14, 22, 55, 118, DateTimeKind.Local).AddTicks(8172));

            migrationBuilder.UpdateData(
                table: "ExpensesCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 2, 10, 14, 22, 55, 118, DateTimeKind.Local).AddTicks(8176));

            migrationBuilder.UpdateData(
                table: "ExpensesCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2022, 2, 10, 14, 22, 55, 118, DateTimeKind.Local).AddTicks(8178));

            migrationBuilder.UpdateData(
                table: "ExpensesCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2022, 2, 10, 14, 22, 55, 118, DateTimeKind.Local).AddTicks(8180));

            migrationBuilder.UpdateData(
                table: "ExpensesCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2022, 2, 10, 14, 22, 55, 118, DateTimeKind.Local).AddTicks(8182));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 2, 10, 14, 22, 55, 118, DateTimeKind.Local).AddTicks(7961));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 2, 10, 14, 22, 55, 118, DateTimeKind.Local).AddTicks(7996));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2022, 2, 10, 14, 22, 55, 118, DateTimeKind.Local).AddTicks(7999));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2022, 2, 10, 14, 22, 55, 118, DateTimeKind.Local).AddTicks(8002));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2022, 2, 10, 14, 22, 55, 118, DateTimeKind.Local).AddTicks(8004));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2022, 2, 10, 14, 22, 55, 118, DateTimeKind.Local).AddTicks(8007));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2022, 2, 10, 14, 22, 55, 118, DateTimeKind.Local).AddTicks(8009));

            migrationBuilder.CreateIndex(
                name: "IX_Recipients_ExpenseCategoryId",
                table: "Recipients",
                column: "ExpenseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipients_UserNavId",
                table: "Recipients",
                column: "UserNavId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipients_ExpensesCategory_ExpenseCategoryId",
                table: "Recipients",
                column: "ExpenseCategoryId",
                principalTable: "ExpensesCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipients_Users_UserNavId",
                table: "Recipients",
                column: "UserNavId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipients_ExpensesCategory_ExpenseCategoryId",
                table: "Recipients");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipients_Users_UserNavId",
                table: "Recipients");

            migrationBuilder.DropIndex(
                name: "IX_Recipients_ExpenseCategoryId",
                table: "Recipients");

            migrationBuilder.DropIndex(
                name: "IX_Recipients_UserNavId",
                table: "Recipients");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Recipients");

            migrationBuilder.DropColumn(
                name: "ExpenseCategoryId",
                table: "Recipients");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Recipients");

            migrationBuilder.DropColumn(
                name: "UserNavId",
                table: "Recipients");

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ExpenseDate" },
                values: new object[] { new DateTime(2022, 2, 2, 14, 43, 53, 937, DateTimeKind.Local).AddTicks(7673), new DateTime(2022, 2, 2, 14, 43, 53, 937, DateTimeKind.Local).AddTicks(7675) });

            migrationBuilder.UpdateData(
                table: "ExpensesCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 2, 2, 14, 43, 53, 937, DateTimeKind.Local).AddTicks(7655));

            migrationBuilder.UpdateData(
                table: "ExpensesCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 2, 2, 14, 43, 53, 937, DateTimeKind.Local).AddTicks(7657));

            migrationBuilder.UpdateData(
                table: "ExpensesCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2022, 2, 2, 14, 43, 53, 937, DateTimeKind.Local).AddTicks(7658));

            migrationBuilder.UpdateData(
                table: "ExpensesCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2022, 2, 2, 14, 43, 53, 937, DateTimeKind.Local).AddTicks(7660));

            migrationBuilder.UpdateData(
                table: "ExpensesCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2022, 2, 2, 14, 43, 53, 937, DateTimeKind.Local).AddTicks(7661));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 2, 2, 14, 43, 53, 937, DateTimeKind.Local).AddTicks(7512));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 2, 2, 14, 43, 53, 937, DateTimeKind.Local).AddTicks(7540));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2022, 2, 2, 14, 43, 53, 937, DateTimeKind.Local).AddTicks(7542));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2022, 2, 2, 14, 43, 53, 937, DateTimeKind.Local).AddTicks(7544));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2022, 2, 2, 14, 43, 53, 937, DateTimeKind.Local).AddTicks(7545));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2022, 2, 2, 14, 43, 53, 937, DateTimeKind.Local).AddTicks(7549));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2022, 2, 2, 14, 43, 53, 937, DateTimeKind.Local).AddTicks(7551));
        }
    }
}
