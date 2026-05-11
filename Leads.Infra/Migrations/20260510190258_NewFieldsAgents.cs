using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leads.Infra.Migrations
{
    /// <inheritdoc />
    public partial class NewFieldsAgents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Agents",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Agents",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Agents",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Agents");
        }
    }
}