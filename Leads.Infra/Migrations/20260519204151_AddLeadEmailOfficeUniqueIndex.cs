using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leads.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddLeadEmailOfficeUniqueIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfficeId",
                table: "Leads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Leads_Email_OfficeId",
                table: "Leads",
                columns: new[] { "Email", "OfficeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Leads_OfficeId",
                table: "Leads",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Offices_OfficeId",
                table: "Leads",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Offices_OfficeId",
                table: "Leads");

            migrationBuilder.DropIndex(
                name: "IX_Leads_Email_OfficeId",
                table: "Leads");

            migrationBuilder.DropIndex(
                name: "IX_Leads_OfficeId",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "Leads");
        }
    }
}
