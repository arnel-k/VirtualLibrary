using Microsoft.EntityFrameworkCore.Migrations;

namespace vLibrary.API.Migrations
{
    public partial class _710_AK_AddressTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Addresses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Addresses",
                nullable: true);
        }
    }
}
