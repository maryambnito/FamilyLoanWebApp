using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyLoan.Infra.DAL.Command.Migrations
{
    public partial class addmoeinentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Moeins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Debtor = table.Column<long>(type: "bigint", nullable: true),
                    Creditor = table.Column<long>(type: "bigint", nullable: true),
                    Sum = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moeins", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moeins");
        }
    }
}
