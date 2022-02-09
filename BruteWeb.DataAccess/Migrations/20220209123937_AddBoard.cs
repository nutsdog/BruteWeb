using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BruteWeb.DataAccess.Migrations
{
    public partial class AddBoard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NUmber",
                table: "Boards",
                newName: "Number");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Boards",
                newName: "NUmber");
        }
    }
}
