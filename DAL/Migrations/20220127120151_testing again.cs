using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class testingagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    Mail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserNavId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => new { x.UserNavId, x.Mail });
                    table.ForeignKey(
                        name: "FK_Email_Users_UserNavId",
                        column: x => x.UserNavId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpensesCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserNavId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpensesCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpensesCategory_Users_UserNavId",
                        column: x => x.UserNavId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    RecipientId = table.Column<int>(type: "int", nullable: true),
                    ExpenseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserNavId = table.Column<int>(type: "int", nullable: false),
                    CategoryNavId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_ExpensesCategory_CategoryNavId",
                        column: x => x.CategoryNavId,
                        principalTable: "ExpensesCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Expenses_Recipients_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Recipients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Expenses_Users_UserNavId",
                        column: x => x.UserNavId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreationDate", "Fname", "Lname", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 27, 13, 1, 51, 380, DateTimeKind.Local).AddTicks(5933), "Julia", "Hook", "Testing123", "JuliaH" },
                    { 2, new DateTime(2022, 1, 27, 13, 1, 51, 380, DateTimeKind.Local).AddTicks(5969), "Alexander", "Volonen", "Testing234", "AlexV" },
                    { 3, new DateTime(2022, 1, 27, 13, 1, 51, 380, DateTimeKind.Local).AddTicks(5971), "Stefan", "Krakowsky", "Testing345", "Peppo" },
                    { 4, new DateTime(2022, 1, 27, 13, 1, 51, 380, DateTimeKind.Local).AddTicks(5973), "Winnie", "Huynh", "Testing456", "WinnieH" },
                    { 5, new DateTime(2022, 1, 27, 13, 1, 51, 380, DateTimeKind.Local).AddTicks(5976), "Eric", "Flodin", "Testing567", "Ericx" },
                    { 6, new DateTime(2022, 1, 27, 13, 1, 51, 380, DateTimeKind.Local).AddTicks(5977), "Anders", "Bergstrom", "Testing678", "AndersB" },
                    { 7, new DateTime(2022, 1, 27, 13, 1, 51, 380, DateTimeKind.Local).AddTicks(5979), "Peter", "Hafid", "Testing789", "PeterH" }
                });

            migrationBuilder.InsertData(
                table: "Email",
                columns: new[] { "Mail", "UserNavId" },
                values: new object[,]
                {
                    { "JuliaH@test.com", 1 },
                    { "AlexV@test.com", 2 },
                    { "Peppo@test.com", 3 },
                    { "WinnieH@test.com", 4 },
                    { "Ericx@test.com", 5 },
                    { "AndersB@test.com", 6 },
                    { "PeterH@test.com", 7 }
                });

            migrationBuilder.InsertData(
                table: "ExpensesCategory",
                columns: new[] { "Id", "CategoryName", "CreationDate", "UserNavId" },
                values: new object[] { 1, "Snacks", new DateTime(2022, 1, 27, 13, 1, 51, 380, DateTimeKind.Local).AddTicks(6109), 1 });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Amount", "CategoryNavId", "Comment", "ExpenseDate", "RecipientId", "UserNavId" },
                values: new object[] { 1, 25f, 1, "Glass", new DateTime(2022, 1, 27, 13, 1, 51, 380, DateTimeKind.Local).AddTicks(6123), null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CategoryNavId",
                table: "Expenses",
                column: "CategoryNavId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_RecipientId",
                table: "Expenses",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_UserNavId",
                table: "Expenses",
                column: "UserNavId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpensesCategory_UserNavId",
                table: "ExpensesCategory",
                column: "UserNavId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "ExpensesCategory");

            migrationBuilder.DropTable(
                name: "Recipients");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
