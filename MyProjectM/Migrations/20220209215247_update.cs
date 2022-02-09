using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProjectM.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_theater_TheaterID",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_TheaterID",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "TheaterID",
                table: "Ticket");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TheaterID",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TheaterID",
                table: "Ticket",
                column: "TheaterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_theater_TheaterID",
                table: "Ticket",
                column: "TheaterID",
                principalTable: "theater",
                principalColumn: "TheaterID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
