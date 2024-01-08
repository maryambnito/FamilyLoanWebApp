using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyLoan.Infra.DAL.Command.Migrations
{
    public partial class addloanremainingtoloanentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "RemainingLoan",
                table: "Loans",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RemainingLoan",
                table: "Loans");
        }
    }
}
