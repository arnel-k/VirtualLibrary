using Microsoft.EntityFrameworkCore.Migrations;

namespace vLibrary.API.Migrations
{
    public partial class _510_AK_Type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
