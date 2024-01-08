using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyLoan.Infra.DAL.Command.Migrations
{
    public partial class changeloanstate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Benefits_BenefitId",
                table: "Payments");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Benefits_BenefitId",
                table: "Payments",
                column: "BenefitId",
                principalTable: "Benefits",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Benefits_BenefitId",
                table: "Payments");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Benefits_BenefitId",
                table: "Payments",
                column: "BenefitId",
                principalTable: "Benefits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
