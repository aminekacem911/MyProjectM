using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProjectM.Migrations
{
    public partial class fieldisadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Isadmin",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Isadmin",
                table: "AspNetUsers");
        }
    }
}
