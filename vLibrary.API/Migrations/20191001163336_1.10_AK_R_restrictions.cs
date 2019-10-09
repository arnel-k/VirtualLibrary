using Microsoft.EntityFrameworkCore.Migrations;

namespace vLibrary.API.Migrations
{
    public partial class _110_AK_R_restrictions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Racks_RackId",
                table: "Books");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Racks_RackId",
                table: "Books",
                column: "RackId",
                principalTable: "Racks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Racks_RackId",
                table: "Books");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Racks_RackId",
                table: "Books",
                column: "RackId",
                principalTable: "Racks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
