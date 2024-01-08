using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyLoan.Infra.DAL.Command.Migrations
{
    public partial class addisdeletedfieldtobenefit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Benefits",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Benefits");
        }
    }
}
