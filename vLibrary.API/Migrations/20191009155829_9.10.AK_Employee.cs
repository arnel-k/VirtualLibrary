using Microsoft.EntityFrameworkCore.Migrations;

namespace vLibrary.API.Migrations
{
    public partial class _910AK_Employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Employees");
        }
    }
}
